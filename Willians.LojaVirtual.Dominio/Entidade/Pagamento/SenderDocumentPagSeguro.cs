﻿using System.Xml.Serialization;

namespace Willians.LojaVirtual.Dominio.Entidades.Pagamento
{
    public class SenderDocumentPagSeguro
    {
        [XmlElement(ElementName = "type")]
        public string Type { get { return "CPF"; } set { } }

        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
}