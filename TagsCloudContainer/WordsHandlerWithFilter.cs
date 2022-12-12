namespace TagsCloudContainer;

public class WordsHandlerWithFilter : DefaultWordsHandler, IWordsHandler
{
    private readonly IEnumerable<string> wordsToExclude;

    private Dictionary<string, int> wordDistribution;

    public WordsHandlerWithFilter(IWordSequenceProvider wordSequenceProvider, IWordFilterProvider wordsFilterProvider)
        : base(wordSequenceProvider)
    {
        wordsToExclude =
            from word in wordsFilterProvider.WordFilter
            select word.ToLower();
    }

    protected override void ProcessSequence()
    {
        base.ProcessSequence();
        WordDistribution = new Dictionary<string, int>(
            from pair in base.WordDistribution
            where !wordsToExclude.Contains(pair.Key)
            select pair);
    }
}