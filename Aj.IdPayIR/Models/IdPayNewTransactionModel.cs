namespace Aj.IdPayIR.Models;

/// <summary>
/// مدل ایجاد یک تراکنش جدید
/// </summary>
public class IdPayNewTransactionModel
{
    /// <summary>
    /// شماره سفارش پذیرنده به طول حداکثر 50 کاراکتر
    /// </summary>
    public string order_id { get; set; }

    /// <summary>
    /// مبلغ مورد نظر به ریال مبلغ باید بین 1,000 ریال تا 500,000,000 ریال باشد
    /// </summary>
    public int amount { get; set; }

    /// <summary>
    /// نام پرداخت کننده به طول حداکثر 255 کاراکتر
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// تلفن همراه پرداخت کننده به طول 11 کاراکتر
    /// </summary>
    public string phone { get; set; }

    /// <summary>
    /// پست الکترونیک پرداخت کننده به طول حداکثر 255 کاراکتر
    /// </summary>
    public string mail { get; set; }

    /// <summary>
    /// توضیح تراکنش به طول حداکثر 255 کاراکتر
    /// </summary>
    public string desc { get; set; }

    /// <summary>
    /// آدرس بازگشت به سایت پذیرنده به طول حداکثر 2048 کاراکتر
    /// </summary>
    public string callback { get; set; }

}//{}