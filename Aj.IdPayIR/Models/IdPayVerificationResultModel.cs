namespace Aj.IdPayIR.Models;

/// <summary>
/// مدل بازگشتی پس از تقاضای برسی وضعیت یک تراکنش پس از بازگشت از درگاه پرداخت
/// </summary>
public class IdPayVerificationResultModel
{
    /// <summary>
    /// وضعیت تراکنش
    /// </summary>
    public int status { get; set; }

    /// <summary>
    /// کد رهگیری آیدی پی
    /// </summary>
    public string track_id { get; set; }

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
    public long amount { get; set; }

    /// <summary>
    /// زمان ایجاد تراکنش
    /// </summary>
    public string date { get; set; }

    // ==================================================================
    // Sub Objects
    // ==================================================================

    /// <summary>
    /// اطلاعات پرداخت تراکنش
    /// </summary>
    public IdPayVerificationResultPaymentModel payment { get; set; }

    /// <summary>
    /// اطلاعات تایید تراکنش
    /// </summary>
    public IdPayVerificationResultVerifyModel verify { get; set; }

}//{}

//=============================================================================
//  Sub Class
//=============================================================================
/// <summary>
/// زیر کلاس مرتبط با کلاس IdPayPaymentVerificationResultModel 
/// </summary>
public class IdPayVerificationResultPaymentModel
{
    /// <summary>
    /// کد رهگیری آیدی پرداخت
    /// </summary>
    public long track_id { get; set; }

    /// <summary>
    /// مبلغ ثبت شده هنگام ایجاد تراکنش
    /// </summary>
    public long amount { get; set; }

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
    public string date { get; set; }

}//{}

//=============================================================================
//  Sub Class
//=============================================================================
/// <summary>
/// زیر کلاس مرتبط با کلاس IdPayPaymentVerificationResultModel 
/// </summary>
public class IdPayVerificationResultVerifyModel
{

    /// <summary>
    /// زمان تائید تراکنش
    /// </summary>
    public string date { get; set; }

}//{}

