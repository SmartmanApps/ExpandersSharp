using System;
namespace ExpandersSharp
{
    public class PropertyItem
    {
        public string Header { get; set; }
        public List<PropertyItemDetails> MyPropertyItems { get; set; }  //This name should be same as the the Binding Name or else binding won't work 

    }
    public class PropertyItemDetails
    {
        public string Reserve { get; set; }
        public string Address { get; set; }

    }
}

