using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
// plural name because represents group of animals v
public class Animals
{
    private string description = "Unknown";
    //private bool descriptionSet = false;
    
    public virtual string Info => $"{Description} <{Size}>";
    public required string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
        /*init
        {
            if (descriptionSet) return;
            descriptionSet = true;

            if (string.IsNullOrWhiteSpace(value))
            {
                description = "Unknown";
                return;
            }

            string temp = value.Trim();

            // przycina do 15 znaków
            if (temp.Length > 15)
                temp = temp.Substring(0, 15).TrimEnd();

            // jeśli jest za krótkie to dopełnij #
            if (temp.Length < 3)
                temp = temp.PadRight(3, '#');

            // pierwsza litera zmienia się na wielką w razi w 
            if (char.IsLower(temp[0]))
                temp = char.ToUpper(temp[0]) + temp.Substring(1);

            description = temp;
        }*/
    }

    public uint Size { get; set; } = 3;

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}