namespace Aj.IdPayIR.Models;

/// <summary>
/// مدل بازگشتی پس از تقاضای یک تراکنش جدید
/// </summary>
public class IdPayNewTransactionResultModel
{
    /// <summary>
    /// کلید منحصر بفرد تراکنش
    /// </summary>
    public string id { get; set; }

    /// <summary>
    /// لینک پرداخت برای انتقال خریدار به درگاه پرداخت
    /// </summary>
    public string link { get; set; }
}//{}
