using System.Data.Common;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.VisualBasic;
using Npgsql;

namespace RecipeApi.Processing;

public static class KeyWordParse
{
    public static async Task<Dictionary<string, int>> ParseKeyWords(
        string toParse,
        PostgresContext db
    )
    {
        var getWords = @"\w+";
        var wordCount = new Dictionary<string, int>();
        var stopWords = await GetStopWords(db);

        Regex
            .Matches(toParse, getWords)
            .ToList()
            .ForEach(w =>
            {
                var cleanWord = w.Value.ToLower();
                if (!stopWords.Contains(cleanWord))
                {
                    try
                    {
                        int count;
                        wordCount.TryGetValue(cleanWord, out count);
                        wordCount[cleanWord] = count += 1;
                    }
                    catch
                    {
                        wordCount.Add(cleanWord, 1);
                    }
                }
            });
        return wordCount;
    }

    private static async Task<List<string?>> GetStopWords(PostgresContext db)
    {
        return await db.StopWords.Select(r => r.Word).ToListAsync();
    }
}
