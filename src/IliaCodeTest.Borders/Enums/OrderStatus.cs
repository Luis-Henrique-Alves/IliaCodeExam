using System.ComponentModel;

namespace IliaTestExam.Borders.Enums
{
    public enum OrderStatus
    {
        [Description("Pendente")]
        Pending = 1,

        [Description("Enviado")]
        Send = 2,

        [Description("Recebido")]
        Received = 3,

    }
}
