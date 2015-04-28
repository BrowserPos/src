namespace HtmlPos.Lib.ClassLib
{
    public abstract class ActionResult
    {
        public object data { get; set; }

        public abstract  object
            Response();
    }
}
