//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class OperOnChiss
    {
        public int id { get; set; }
        public int id_num { get; set; }
        public int id_num2 { get; set; }
        public int Resulters { get; set; }
        public int id_oper { get; set; }
    
        public virtual Operation Operation { get; set; }
        public virtual SisSchis SisSchis { get; set; }
        public virtual SisSchis SisSchis1 { get; set; }
        public virtual SisSchis SisSchis2 { get; set; }
    }
}
