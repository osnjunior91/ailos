using Newtonsoft.Json;
using Questao2;
using System.Net.Http.Json;

public class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string APIURL = $"https://jsonmock.hackerrank.com/api/football_matches";
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        string url = $"{APIURL}?year={year}";
        var homeGoals = await getGoalsLocation(url, team, true);
        var visitingGoals = await getGoalsLocation(url, team, false);
        return homeGoals + visitingGoals;
    }

    public static async Task<int> getGoalsLocation(string url, string team, bool home)
    {
        int totalGoals = 0;
        int currentPage = 1;
        string teamVar = home ? "team1" : "team2";
        
        while(true)
        {
            HttpResponseMessage response = await client.GetAsync($"{url}&{teamVar}={team}&page={currentPage}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ApiResponse result = JsonConvert.DeserializeObject<ApiResponse>(content);
                totalGoals += home ? result.Data.Sum(x => x.Team1goals) : result.Data.Sum(x => x.Team2goals);

                if (currentPage >= result.Total_pages)
                    break;

                currentPage++;
            }
            else
            {
                break;
            }
        }

        return totalGoals;
    }

}