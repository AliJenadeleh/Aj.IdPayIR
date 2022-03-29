using Aj.IdPayIR.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace Aj.IdPayIR;

/// <summary>
/// IdPay Class
/// </summary>
public class IdPay
{

    /// <summary>
    /// Authenticate Tag
    /// </summary>
    private const string TAG_X_API_KEY = "X-API-KEY";

    /// <summary>
    /// Active sand box mode (1|0)
    /// </summary>
    private const string TAG_X_SANDBOX = "X-SANDBOX";

    /// <summary>
    /// Start new transaction api
    /// </summary>
    private const string URL_NEW_TRANSACTION = "https://api.idpay.ir/v1.1/payment";

    /// <summary>
    /// Verify URL
    /// </summary>
    private const string URL_VERIFY_TRANSACTION = "https://api.idpay.ir/v1.1/payment/verify";


    /// <summary>
    /// Id pay referer
    /// </summary>
    public const string Referer = "https://idpay.ir";

    private readonly HttpClient client;

    public IdPay(HttpClient Client)
    {
        this.client = Client;
    }

    public IdPay()
    {
        this.client = new HttpClient();
    }

    /// <summary>
    /// ایجاد یک تراکنش جدید
    /// </summary>
    /// <param name="ApiKey">کد دریافتی از IdPay.ir</param>
    /// <param name="Amount">مبلغ تراکنش به ریال</param>
    /// <param name="Phone">شماره تلفن پرداخت کننده</param>
    /// <param name="Mail">ایمیل پرداخت کننده</param>
    /// <param name="Name">نام پرداخت کننده</param>
    /// <param name="OrderId">شماره سفارش پذیرنده به طول حداکثر 50 کاراکتر</param>
    /// <param name="Description">توضیحات</param>
    /// <param name="CallBack">لینک برگشت پس از انتقال به درگاه</param>
    /// <param name="UseSandBox">استفاده از حالت تستی پیشفرض فعال میباشد</param>
    public async Task<IdPayNewTransactionResultModel?>
                 StartTransactionAsync(string ApiKey
                                       , int Amount
                                       , string Phone
                                       , string Mail
                                       , string Name
                                       , string OrderId
                                       , string Description
                                       , string CallBack
                                       , bool UseSandBox = true)
    {

        var model = new IdPayNewTransactionModel()
        {
            amount = Amount,
            phone = Phone,
            mail = Mail,
            name = Name,
            order_id = OrderId,
            desc = Description,
            callback = CallBack
        };

        var json = JsonConvert.SerializeObject(model);

        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.Add(TAG_X_API_KEY, ApiKey);

        if (UseSandBox)
            client.DefaultRequestHeaders.Add(TAG_X_SANDBOX, "1");
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(URL_NEW_TRANSACTION, requestContent);
        res.EnsureSuccessStatusCode();

        var resultContent = await res.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IdPayNewTransactionResultModel>(resultContent);
    }//()

    /// <summary>
    /// اعتبار سنجی یک تراکنش پس از بازگشت از درگاه پرداخت
    /// </summary>
    /// <param name="ApiKey">کد دریافتی از IdPay.ir</param>
    /// <param name="Id">کلید منحصر بفرد تراکنش که در مرحله ایجاد تراکنش دریافت شده است</param>
    /// <param name="OrderId">شماره سفارش پذیرنده که در مرحله ایجاد تراکنش ارسال شده است</param>
    /// <param name="UseSandBox">استفاده از حالت تستی (به صورت پیش فرض فعال میباشد)</param>
    public async Task<IdPayVerificationResultModel?>
                 VerifyTransactionAsync(string ApiKey,
                                        string Id,
                                        string OrderId,
                                        bool UseSandBox = true)
    {

        var payModel = new IdPayVerificationModel()
        {
            id = Id,
            order_id = OrderId
        };

        var json = JsonConvert.SerializeObject(payModel);


        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.Add(TAG_X_API_KEY, ApiKey);

        if (UseSandBox)
            client.DefaultRequestHeaders.Add(TAG_X_SANDBOX, "1");
        var requestContent = new StringContent(json, Encoding.UTF8, "application/json");
        var res = await client.PostAsync(URL_VERIFY_TRANSACTION, requestContent);
        res.EnsureSuccessStatusCode();

        var resultContent = await res.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IdPayVerificationResultModel>(resultContent);
    }//();

}//{}
