namespace PostService;

/// <summary>
/// Модель для оновлення існуючого поштового відправлення (дата-контракт запиту PUT)
/// </summary>
public class PostingPutDto
{
    /// <summary>
    /// Оновлене ПІБ або найменування відправника
    /// </summary>
    public string Sender { get; set; } = string.Empty;

    /// <summary>
    /// Оновлене ПІБ або найменування отримувача
    /// </summary>
    public string Receiver { get; set; } = string.Empty;

    /// <summary>
    /// Оновлений опис вмісту поштового відправлення
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Оновлена вага поштового відправлення у кілограмах
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Оновлена вартість доставки поштового відправлення у гривнях
    /// </summary>
    public decimal Price { get; set; }
}