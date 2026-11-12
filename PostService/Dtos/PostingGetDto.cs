namespace PostService;

/// <summary>
/// Модель поштового відправлення для перегляду (дата-контракт відповіді)
/// </summary>
public class PostingGetDto
{
    /// <summary>
    /// Унікальний ідентифікатор поштового відправлення
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// ПІБ або найменування відправника
    /// </summary>
    public string Sender { get; set; } = string.Empty;

    /// <summary>
    /// ПІБ або найменування отримувача
    /// </summary>
    public string Receiver { get; set; } = string.Empty;

    /// <summary>
    /// Опис вмісту поштового відправлення
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Вага поштового відправлення у кілограмах
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Вартість доставки поштового відправлення у гривнях
    /// </summary>
    public decimal Price { get; set; }
}