using DocumentFormat.OpenXml.InkML;

namespace Aj.IdPayIR.Models;

/// <summary>
/// مدل برگشت پس از ایجاد تراکنش و بازگشت پرداخت
/// </summary>
public class IdPayReturnModel
{

    public IdPayReturnModel()
    {
        this.date = new Timestamp();
    }

    /// <summary>
    /// وضعیت تراکنش
    /// </summary>
    public int status { get; set; }

    /// <summary>
    /// کد رهگیری آیدی پی
    /// </summary>
    public long track_id { get; set; }

    /// <summary>
    /// کلید منحصر بفرد تراکنش که در مرحله ایجاد تراکنش دریافت شده است
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// شماره سفارش پذیرنده که در مرحله ایجاد تراکنش ارسال شده است
    /// </summary>
    public string order_id { get; set; }

    /// <summary>
    /// مبلغ ثبت شده هنگام ایجاد تراکنش
    /// </summary>
    public int amount { get; set; }

    /// <summary>
    /// شماره کارت پرداخت کننده با فرمت 123456******1234
    /// </summary>
    public string card_no { get; set; }

    /// <summary>
    /// هش شماره کارت پرداخت کننده با الگوریتم SHA256
    /// </summary>
    public string hashed_card_no { get; set; }

    /// <summary>
    /// زمان پرداخت تراکنش
    /// </summary>
    public Timestamp date { get; set; }

    /// <summary>
    /// وظعیت تراکنش
    /// 10 == انتظار برای اعتبار سنجی
    /// 100 == پرداخت کامل شده است
    /// </summary>
    public bool IsWaitForVerify => status == 10;


}//{}
