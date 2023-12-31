using Content.Shared.MassMedia.Systems;
using Robust.Shared.Serialization;

namespace Content.Shared.MassMedia.Components;

[Serializable, NetSerializable]
public enum NewsWriteUiKey : byte
{
    Key
}

[Serializable, NetSerializable]
public sealed class NewsWriteBoundUserInterfaceState : BoundUserInterfaceState
{
    public NewsArticle[] Articles;
    public bool ShareAvalible;

    public NewsWriteBoundUserInterfaceState(NewsArticle[] articles, bool shareAvalible)
    {
        Articles = articles;
        ShareAvalible = shareAvalible;
    }
}

[Serializable, NetSerializable]
public sealed class NewsWriteShareMessage : BoundUserInterfaceMessage
{
    public NewsArticle Article;

    public NewsWriteShareMessage(NewsArticle article)
    {
        Article = article;
    }
}

[Serializable, NetSerializable]
public sealed class NewsWriteDeleteMessage : BoundUserInterfaceMessage
{
    public int ArticleNum;

    public NewsWriteDeleteMessage(int num)
    {
        ArticleNum = num;
    }
}

[Serializable, NetSerializable]
public sealed class NewsWriteArticlesRequestMessage : BoundUserInterfaceMessage
{
    public NewsWriteArticlesRequestMessage()
    {
    }
}
