using Hub.Controllers.Info;
using Hub.Models.Event;
using Hub.Models.OrganizationFeature;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hub.Models.Organization
{
    public class Org
    {
        [Key]
        public int Ids { get; set; }


        public string Id { get; set; }     // this has to pull current signed in user 
        [ForeignKey("Id")]
      //  public HubUser HubUser { get; set; }



        [Required, Display(Name = "Select Organization Category")]    //once registered this cannot be chnaged 
        public int ModuleCategoryId { get; set; }
        public ModuleCategory ModuleCategory { get; set; }


        public enum ServiceType
        {
            Private,
            Public
        }

        [Required, EnumDataType(typeof(ServiceType)), Display(Name = "Select Organization Service")] // organization need to select if they are private or public
        public ServiceType serviceType { get; set; }
        public enum OrganizationType
        {
            National,
            International,
            Multinational
        }


        [Required, EnumDataType(typeof(OrganizationType)), Display(Name = "Select Organization Type")] //organization must select if they are National or International
        public OrganizationType organizationType { get; set; }



        [Required, StringLength(100, MinimumLength = 5), Display(Name = "Your Organization Name")]
        public string OrgName { get; set; }



        [DataType(DataType.EmailAddress), Display(Name = "Your Secondary Email")]
        public string SecondEmail { get; set; }



        [DataType(DataType.PhoneNumber), Display(Name = "Your Secondary Phone Number")]
        public string SecondPhone { get; set; }


        [StringLength(500, MinimumLength = 0), Display(Name = "Short Description Of Your Organization")]
        public string? ShortDesc { get; set; }


        [StringLength(2000, MinimumLength = 0), Display(Name = "Long Description Of Your Organization")]
        public string? LongDesc { get; set; }



        [Display(Name = "Your Organization Logo Image"), StringLength(100)]
        public string Logo { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }


        [Display(Name = "Your Organization Main Banner Image"), StringLength(100)]
        public string BannerImg { get; set; }



        [Display(Name = "Your Organization Featured Images"), StringLength(100)]
        public string OrgImg { get; set; }

        [NotMapped]
        public List<IFormFile> OrgImageFiles { get; set; }


        [Required, Display(Name = "Organization Status")]  // This is to control the organization policy and claim for future use (Example if the nauual fee is paid this need to auto turn true)
        public Boolean Status { get; set; } = false;


        public DateTime OrgCreatedDate { get; set; } = DateTime.UtcNow;  // To get current date and time when organization was registed in our system

       // public ICollection<OrgImage> OrgImages { get; set; }

        public ICollection<EventRego> EventRegos { get; set; }  //Added by sumesh need to check - checked by roshan and surace

        public ICollection<NewsRegister> NewsRegisters { get; set; } //one Org can post multiple newsregister

        //public  ICollection<Annual> Annuals { get; set; } this secontion is removed by discussing with roshan and surace  //one user will have Annual fee each year ?? so isi it one to many or one to one 

        public ICollection<Facility> Facilities { get; set; }  // one organization will have multiple facilities 

        public ICollection<Fee> Fees { get; set; } //one organization will have their multiple internal fees like transportation feee ,hostel fee 
    }
}