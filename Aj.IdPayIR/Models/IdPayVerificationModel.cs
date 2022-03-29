namespace Aj.IdPayIR.Models;

/// <summary>
/// مدل اعتبار سنجی یک تراکنش پس از بازگشت از درگاه پرداخت
/// </summary>
public class IdPayVerificationModel
{
    /// <summary>
    /// کلید منحصر بفرد تراکنش که در مرحله ایجاد تراکنش دریافت شده است
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// شماره سفارش پذیرنده که در مرحله ایجاد تراکنش ارسال شده است
    /// </summary>
    public string order_id { get; set; }
}//{}
