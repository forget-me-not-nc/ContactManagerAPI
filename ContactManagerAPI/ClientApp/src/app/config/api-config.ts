export class ApiConfig {
  private static readonly API_ROUTE: string = 'http://localhost:5056/';
  public static readonly CONTACT_INFO_API: string = ApiConfig.API_ROUTE + 'api/contactinfo/';
  public static readonly CSV_IMPORT_API: string = ApiConfig.API_ROUTE + 'api/csv/';
}
