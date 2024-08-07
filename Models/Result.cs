using System.Text.Json;
using System.Text.Json.Serialization;

namespace Simplz.Europa.SafetyGateAlerts.Models;

public sealed record Result
{
    [JsonPropertyName("alert_level")]
    public string? AlertLevel { get; set; }

    [JsonPropertyName("alert_group")]
    public string? AlertGroup { get; set; }

    [JsonPropertyName("alert_number")]
    public string AlertNumber { get; set; } = string.Empty;

    [JsonPropertyName("alert_country")]
    public string? AlertCountry { get; set; }

    [JsonPropertyName("product_country")]
    public string? ProductCountry { get; set; }

    [JsonPropertyName("product_counterfeit")]
    public string? ProductCounterfeit { get; set; }

    // [JsonPropertyName("alert_type")]
    // public List<string> AlertType { get; set; } = [];

    [JsonPropertyName("risk_legal_provision")]
    public string? RiskLegalProvision { get; set; }

    [JsonPropertyName("product_type")]
    public string? ProductType { get; set; }

    [JsonPropertyName("product_name")]
    public string? ProductName { get; set; }

    [JsonPropertyName("product_description")]
    public string? ProductDescription { get; set; }

    [JsonPropertyName("product_brand")]
    public string? ProductBrand { get; set; }

    [JsonPropertyName("product_category")]
    public string? ProductCategory { get; set; }

    [JsonPropertyName("product_model_type")]
    public string? ProductModelType { get; set; }

    [JsonPropertyName("oecd_portal_category")]
    public string? OecdPortalCategory { get; set; }

    [JsonPropertyName("alert_description")]
    public string? AlertDescription { get; set; }

    [JsonPropertyName("technical_defect")]
    public string? TechnicalDefect { get; set; }

    // [JsonPropertyName("alert_other_countries")]
    // public List<string> AlertOtherCountries { get; set; } = [];

    [JsonPropertyName("product_recall_url")]
    public string? ProductRecallUrl { get; set; }

    [JsonPropertyName("rapex_url")]
    public string RapexUrl { get; set; } = string.Empty;

    [JsonPropertyName("product_barcode")]
    public string? ProductBarcode { get; set; }

    [JsonPropertyName("product_batch_number")]
    public string? ProductBatchNumber { get; set; }

    // [JsonPropertyName("product_recall_code")]
    // public string? ProductRecallCode { get; set; }

    // [JsonPropertyName("product_production_date")]
    // public DateTime? ProductProductionDate { get; set; }

    [JsonPropertyName("product_packaging_description")]
    public string? ProductPackagingDescription { get; set; }

    [JsonPropertyName("alert_date")]
    public string? AlertDate { get; set; }

    [JsonPropertyName("modification_date")]
    public DateTime ModificationDate { get; set; }

    [JsonPropertyName("product_image")]
    public string? ProductImage { get; set; }

    // [JsonPropertyName("product_other_images")]
    // public List<string> ProductOtherImages { get; set; } = [];

    // [JsonPropertyName("measures_country")]
    // public List<string> MeasuresCountry { get; set; } = [];

    public static explicit operator Data.HistoryItem(Result result)
    {
        return new Data.HistoryItem(result.RapexUrl, JsonSerializer.Serialize(result), result.ModificationDate)
        {
            Title = result.ProductName,
            Description = result.ProductDescription,
            Url = result.RapexUrl
        };
    }
}
