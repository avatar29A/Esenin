namespace Hqub.Esenin.App.Messages
{
    public class ChangeSelectedQuatrainMessage
    {
        public string QuatrainId { get; set; }

        public ChangeSelectedQuatrainMessage(string quatraineId)
        {
            QuatrainId = quatraineId;
        }
    }
}
