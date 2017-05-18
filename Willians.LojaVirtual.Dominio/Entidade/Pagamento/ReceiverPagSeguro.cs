using System.Xml.Serialization;

namespace Willians.LojaVirtual.Dominio.Entidades.Pagamento
{
    public class ReceiverPagSeguro
    {
        [XmlElement(ElementName = "email")]
        public string Email { get { return "williansfr@hotmail.com"; } set { } }
    }
}