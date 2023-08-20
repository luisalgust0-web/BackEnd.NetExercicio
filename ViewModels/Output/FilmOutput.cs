namespace WebExercicios.ViewModels.Output;
public class FilmOutput
{
    public int Film_id {get;set;}
    public string Title {get;set;}
    public string Description {get;set;}
    public int Release_year {get;set;}
    public int Language_id {get;set;}
    public string LanguageName {get;set;}
    public int Original_language_id {get;set;}
    public string OriginaLanguageName {get;set;}
    public int Rental_duration {get;set;}
    public int Rental_rate {get;set;}
    public int Length {get;set;}
    public int Replacement_cost {get;set;}
    public string Rating {get;set;}
    public string Special_features {get;set;}
    public DateTime Last_update {get;set;}
}
