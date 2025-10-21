namespace jp.illusive_isc.IllusoryReframe.IKUSIA.Rurune
{
    internal class Tail : Base
    {
        internal override void ChangeObj(params string[] delPath)
        {
            SetWeight(
                avatarRoot.Find("sharktail"),
                "gizagiza",
                ((RuruneReframe)reframe).TailGizaFlg ? 0 : 100
            );
            SetWeight(
                avatarRoot.Find("sharktail"),
                "sebire giza",
                ((RuruneReframe)reframe).TailGizaFlg ? 0 : 100
            );
        }
    }
}
