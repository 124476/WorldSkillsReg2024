//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1_2_4_Session.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Place
    {
        public int Id { get; set; }
        public Nullable<int> PacientId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> TipId { get; set; }
        public Nullable<int> MeropriationId { get; set; }
        public Nullable<int> Result { get; set; }
        public string Recomendation { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Meroprition Meroprition { get; set; }
        public virtual Pacient Pacient { get; set; }
        public virtual Result Result1 { get; set; }
        public virtual Tip Tip { get; set; }
    }
}
