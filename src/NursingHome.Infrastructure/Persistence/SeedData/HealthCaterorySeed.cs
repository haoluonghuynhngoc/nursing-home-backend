using NursingHome.Domain.Entities;

namespace NursingHome.Infrastructure.Persistence.SeedData;
internal static class HealthCaterorySeed
{
    public static List<HealthCategory> Default =>
         new List<HealthCategory>
         {
            new HealthCategory {
               Name = "Blood Sugar",
               ImageUrl ="https://static.vecteezy.com/system/resources/previews/005/116/379/original/blood-sugar-logo-template-this-design-use-glucose-symbol-suitable-for-medical-business-free-vector.jpg" ,
               Description="None",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit { Name = "Fasting Blood Sugar", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "Postprandial Blood Sugar", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "HbA1c", Description = "None",UnitType ="%" }
                }
            },
            new HealthCategory {
               Name = "Cholesterol" ,
               ImageUrl="https://media.gettyimages.com/id/1413404652/vector/cholesterol-education-month-september-vector.jpg?s=612x612&w=gi&k=20&c=Q4dSiTTOlce99S6BqIdc0O8KPMiuJmb2_1wvoD8uGxU=",
               Description="None",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit { Name = "Total Cholesterol", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "HDL Cholesterol", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "LDL Cholesterol", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "Triglycerides", Description = "None",UnitType ="mg/dL" }
                }
            },
            new HealthCategory {
               Name = "Lung",
               ImageUrl="https://static.vecteezy.com/system/resources/previews/000/682/073/original/lungs-icon-vector.jpghttps://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiucESZqFtkbgcn55W54Q5Q3224Ntm7QpYBg&s",
               Description="None",
               MeasureUnits = new List<MeasureUnit>
               {
                  new MeasureUnit { Name = "Lung Capacity", Description = "None" ,UnitType ="mL" },
                  new MeasureUnit { Name = "Oxygen Level", Description = "None",UnitType ="SpO₂" }
               }
            },
            new HealthCategory {
               Name = "Kidney",
               ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAP6gKcYE3S5RZPb3KnLtazpe7dfVKU8TEhg&s",
               Description="None",
               MeasureUnits = new List<MeasureUnit>
                {
                    new MeasureUnit { Name = "Creatinine", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "Blood Urea Nitrogen", Description = "None",UnitType ="mg/dL" },
                    new MeasureUnit { Name = "eGFR", Description = "None",UnitType ="mL/min/1.73m²" }
                }
            },
            new HealthCategory {
               Name = "Heart",
               ImageUrl="https://t4.ftcdn.net/jpg/02/67/21/75/360_F_267217594_MBBpEMgCXkQr8USHMo2lyjPcp8W8tg46.jpg",
               Description="None",
               MeasureUnits = new List<MeasureUnit>
                 {
                      new MeasureUnit { Name = "Blood Pressure", Description = "None",UnitType ="mmHg" },
                      new MeasureUnit { Name = "Heart Rate", Description = "None",UnitType ="bpm" }
                 }
            },
         };
}
