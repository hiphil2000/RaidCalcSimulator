namespace RaidCalcCore.Models
{
    public class TimeLine
    {
        public string Command { get; set; }
        public string Action { get; set; }

        public TimeLine (string Command, string Action)
        {
            this.Command = Command;
            this.Action = Action;
        }
    }
}