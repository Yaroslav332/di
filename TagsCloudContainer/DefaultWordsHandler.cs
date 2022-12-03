namespace TagsCloudContainer;

public class DefaultWordsHandler : IWordsHandler
{
    public Dictionary<string, int> WordDistribution { get; } = new();
    private IEnumerable<string> WordSequence;
    public DefaultWordsHandler(IEnumerable<string> WordSequence)
    {
        this.WordSequence = WordSequence;
        ProcessSequence();
    }

    private void ProcessSequence()
    {
        foreach (var word in WordSequence)
        {
            if (WordDistribution.ContainsKey(word)) WordDistribution[word] += 1;
            else WordDistribution.Add(word, 1);
        }
    }
}