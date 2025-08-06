namespace ModuleTech.Application.Helpers.Options;

public class KeycloakOptions
{
    public string master_realm { get; set; } = null!;
    public string moduleTech_realm { get; set; } = null!;
    public string grant_type { get; set; } = null!;
    public string master_client_id { get; set; } = null!;
    public string moduleTech_client_id { get; set; } = null!;
    public string moduleTech_client_secret { get; set; } = null!;
    public string moduleTech_client_ref_id { get; set; } = null!;
    public string base_address { get; set; } = null!;
    public string ecommerce_grant_type { get; set; } = null!;
    public string refresh_token_grant_type { get; set; } = null!;
    public string ecommerce_scope { get; set; } = null!;
    public string master_client_secret { get; set; } = null!;

}
