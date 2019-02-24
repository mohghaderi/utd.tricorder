using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UTD.Tricorder.Website.Helpers
{
    public static class PatientHistory
    {

        //public class MedicalCondition
        //{
        //    public string Code { get; set; }
        //    public string Tilte { get; set; }
        //    public string CategoryCode { get; set; }
        //}

        //private static List<MedicalCondition> MedicalConditionsList;

        //private static List<MedicalCondition> GetList()
        //{
        //    if (MedicalConditionsList == null)
        //    {
        //        MedicalConditionsList = new List<MedicalCondition>();
        //        var list = MedicalConditionsList;


            
        //    }
        //    return MedicalConditionsList;
        //}


        //private List<MedicalCondition> CreateMedicalConditionsList()
        //{
        //    var list = new List<MedicalCondition>();


        //    //list.Add(new MedicalCondition() { Code = "", Tilte = "", CategoryCode = "" });

        //}


        public static MvcHtmlString MedicalCheckBox(string title, string sectionTitle)
        {
            string id = FWHtml.CreateSafeIDForTitle(title);
            string modelPrefix = "model.Condition.";
            return CheckBox(modelPrefix, id, title);
        }

        public static MvcHtmlString CheckBox(string modelPrefix, string name, string title)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"checkbox\">");
            sb.Append("<label>");
            sb.Append("<input type=\"checkbox\" ");
            sb.Append(" name=\"").Append(name).Append("\"");
            sb.Append(" data-ng-model=\"").Append(modelPrefix).Append(name).Append("\"");
            //sb.Append(" data-bv-notempty=\"true\"");
            //sb.Append(" ng-icheck");
            sb.Append(" >");
            sb.Append(" " + title);
            sb.Append("</input>");
            sb.Append("</label>");
            sb.Append("</div>");

            return new MvcHtmlString(sb.ToString());
        }


        public static MvcHtmlString ImmunizationCheckBox(string title, string sectionTitle)
        {
            string id = FWHtml.CreateSafeIDForTitle(title);
            string modelPrefix = "model.Immunization.";
            return FWHtml.CheckBox(modelPrefix, id, title);
        }


        public static MvcHtmlString GetAccordionSectionHeader(string sectionTitle)
        {
            string id = FWHtml.CreateSafeIDForTitle(sectionTitle);

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"panel panel-default\">");
            sb.Append("	<div class=\"panel-heading\">");
            sb.Append("		<h4 class=\"panel-title\">");
            //sb.Append("			<a href=\"javascript:CollapsePanel('" + id + "')\" >");
            sb.Append("				").Append(sectionTitle);
            //sb.Append("			</a>");
            sb.Append("		</h4>");
            sb.Append("	</div>");
            sb.Append("	<div id=\"collapse" + id + "\" class=\"panel-collapse collapse in\">");
            sb.Append("		<div class=\"panel-body\">");
            //sb.Append("<div class=\"form-group\">");


            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString GetAccordionSectionFooter(string sectionTitle)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("      </div>");
            sb.Append("    </div>");
            sb.Append("  </div>");
            //sb.Append("</div>");
            return new MvcHtmlString(sb.ToString());
        }




        //private static string MedicalCheckBox(string name)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<input type=\"checkbox\" ");
        //    sb.Append(" name=\"name\" + );
        //    sb.Append(" />");

        //    return sb.ToString();
        //}

    }
}


//anaphylaxis	Anaphylaxis (Severe Allergic Reaction)	Allergies
//chronic_rhinitis	Chronic Rhinitis	Allergies
//cold_flu_allergy	Cold / Flu / Allergies	Allergies
//food_allergy	Food Allergy	Allergies
//hives	Hives	Allergies
//latex_allergy	Latex Allergy	Allergies
//sinusitis	Sinusitis	Allergies
//alzheimers_disease	Alzheimer's Disease	Allergies
//urinary_incontinence	Bladder Incontinence	Allergies
//dementia	Dementia	Allergies
		
//arthritis	Arthritis	Arthritis
//ankylosing_spondylitis	Ankylosing Spondylitis	Arthritis
//fibromyalgia	Fibromyalgia	Arthritis
//gout	Gout	Arthritis
//systemic_lupus	Lupus	Arthritis
//osteoarthritis	Osteoarthritis	Arthritis
//psoriatic_arthritis	Psoriatic Arthritis	Arthritis
//reactive_arthritis	Reactive Arthritis	Arthritis
//rheumatoid_arthritis	Rheumatoid Arthritis	Arthritis
		
		
		
		
//cancer	Cancer - General	Cancer
//brain_tumor	Brain Tumor	Cancer
//bladder_cancer	Bladder Cancer	Cancer
//breast_cancer	Breast Cancer	Cancer
//cervical_cancer	Cervical Cancer	Cancer
//colon_polyps	Colon Polyps	Cancer
//liver_cancer	Liver Cancer	Cancer
//lung_cancer	Lung Cancer	Cancer
//pancreatic_cancer	Pancreatic Cancer	Cancer
//prostate_cancer	Prostate Cancer	Cancer
//skin_cancer	Skin Cancer	Cancer
//testicular_cancer	Testicular Cancer	Cancer
		
//cholesterol	Cholesterol	Cholesterol
//fiber	Fiber	Cholesterol
//heart_attack	Heart Attack	Cholesterol
		
//acupuncture	Acupuncture	Chronic Pain
//chronic_pain	Acute and Chronic Pain	Chronic Pain
//cortisone_injection	Cortisone Injection	Chronic Pain
//degenerative_disc	Degenerative Disc	Chronic Pain
//low_back_pain	Low Back Pain	Chronic Pain
		
//aches_pain_fever	Aches, Pain, Fever	Cold and Flu
//chronic_cough	Chronic Cough	Cold and Flu
//common_cold	Common Cold	Cold and Flu
//encephalitis_and_meningitis	Encephalitis and Meningitis	Cold and Flu
//eustachian_tube_problems	Eustachian Tube Problems	Cold and Flu
//influenza	Flu (Influenza)	Cold and Flu
//pneumonia	Pneumonia	Cold and Flu
//severe_acute_respiratory_syndrome_sars	SARS	Cold and Flu
//sinusitis	Sinusitis	Cold and Flu
//sore_throat	Sore Throat	Cold and Flu
//strep_throat	Strep Throat	Cold and Flu
//swine_flu	Swine Flu (H1N1 Virus)	Cold and Flu
//adenoids_and_tonsils	Tonsillitis and Adenoiditis	Cold and Flu
		
//depression	Bipolar Disorder	Depression
//depression	Depression	Depression
//depression	Dysthymia	Depression
//panic_disorder	Panic Disorder	Depression
//posttraumatic_stress_disorder	Post Traumatic Stress Disorder	Depression
//seasonal_affective_disorder_sad	Seasonal Affective Disorder (SAD)	Depression
//stress	Stress	Depression
		
//diabetes_mellitus	Diabetes Mellitus	Diabetes
//diabetes_insipidus	Diabetes Insipidus	Diabetes
		
//abdominal_pain	Abdominal Pain	Digestion
//appendicitis	Appendicitis	Digestion
//ulcerative_colitis	Ulcerative Colitis	Digestion
//constipation	Constipation	Digestion
//crohns_disease	Crohn's Disease	Digestion
//diarrhea	Diarrhea	Digestion
//dyspepsia	Dyspepsia (Indigestion)	Digestion
//inflammatory_bowel_disease_intestinal_problems	Inflammatory Bowel Disease (IBD)	Digestion
//intestinal_gas_belching_bloating_flatulence	Intestinal Gas	Digestion
//gastroesophageal_reflux_disease_gerd	GERD (Heartburn, Acid Reflux)	Digestion
//hemorrhoids	Hemorrhoids	Digestion
//irritable_bowel_syndrome	Irritable Bowel Syndrome (IBS)	Digestion
//lactose_intolerance	Lactose Intolerance	Digestion
//laxatives_for_constipation	Laxatives for Constipation	Digestion
//motion_sickness	Motion Sickness	Digestion
		
//cataracts	Cataracts	Eyesight
//eye_allergy	Eye Allergy	Eyesight
//eye_care	Eye Care	Eyesight
//glaucoma	Glaucoma	Eyesight
//lasik_eye_surgery	LASIK Eye Surgery	Eyesight
//macular_degeneration_age-related_type	Macular Degeneration	Eyesight
//pink_eye	Pink Eye (Conjunctivitis)	Eyesight
//retinal_detachment	Retinal Detachment	Eyesight
//sjogrens_syndrome	Sjogren's Syndrome	Eyesight
		
//angina	Angina	Heart
//congenital_heart_disease	Congenital Heart Disease	Heart
//coronary_angiogram	Coronary Angiogram	Heart
//coronary_angioplasty	Coronary Angioplasty	Heart
//coronary_artery_bypass_graft	Coronary Artery Bypass	Heart
//heart_attack	Heart Attack	Heart
//mitral_valve_prolapse	Heart Murmurs	Heart
//palpitations	Heart Palpitations	Heart
//cholesterol	High Cholesterol	Heart
//stroke	Stroke	Heart
		
//cirrhosis	Cirrhosis of the Liver	Hepatitis
//essential_mixed_cryoglobulinemia	Essential Mixed Cryoglobulinemia	Hepatitis
//hepatitis_b	Hepatitis B	Hepatitis
//hepatitis_c	Hepatitis C	Hepatitis
//hepatitis_immunizations	Hepatitis A and B	Hepatitis
//jaundice	Jaundice	Hepatitis
//lichen_planus	Lichen Planus	Hepatitis
		
//high_blood_pressure	High Blood Pressure (Hypertension)	High Blood Pressure
//pulmonary_hypertension	Pulmonary Hypertension	High Blood Pressure
		
//human_immunodeficiency_virus_hiv_aids	Acquired Immunodeficiency Disease (AIDS) and Human Immunodeficiency Virus	AIDS
		
//botulism	Botulism	Infectious Disease
//dengue_fever	Dengue Fever	Infectious Disease
//mad_cow_disease	Mad Cow Disease	Infectious Disease
//malaria	Malaria	Infectious Disease
//encephalitis_and_meningitis	Meningitis	Infectious Disease
//mrsa_infection	MRSA	Infectious Disease
//rabies	Rabies	Infectious Disease
//staph_infection	Staph Infection	Infectious Disease
//thrush_and_other_yeast_infections_in_children	Thrush	Infectious Disease
//west_nile_encephalitis	West Nile Virus	Infectious Disease
		
//cirrhosis	Cirrhosis of the Liver	Liver
//fatty_liver	Non-alcoholic Fatty Liver	Liver
//iron_overload	Hemochromatosis (Iron Overload)	Liver
//hepatitis_b	Hepatitis B	Liver
//hepatitis_c	Hepatitis C	Liver
//jaundice	Jaundice	Liver
//liver_blood_tests	Liver Blood Tests	Liver
//primary_biliary_cirrhosis	Primary Biliary Cirrhosis (PBC)	Liver
//primary_sclerosing_cholangitis	Primary Sclerosing Cholangitis (PSC)	Liver
		
//asthma	Asthma	Lungs
//chronic_obstructive_pulmonary_disease_copd	Chronic Obstructive Pulmonary Disease (COPD)	Lungs
//chronic_obstructive_pulmonary_disease_copd	Emphysema	Lungs
//lung_cancer	Lung Cancer	Lungs
//pneumonia	Pneumonia	Lungs
//severe_acute_respiratory_syndrome_sars	Severe Acute Respiratory Syndrome (SARS)	Lungs
//smokers_lung_pathology_photo_essay	Smoker's Lung Photo Essay	Lungs
//smoking_and_quitting_smoking	Smoking and Quitting Smoking	Lungs
//        Lungs
//conjugated_estrogens_vaginal_cream	Hormone Creams	Lungs
//hormone_therapy	Hormone Replacement Therapy	Lungs
//alternative_treatments_for_hot_flashes	Hot Flashes - Alternative Treatments	Lungs
//menopause	Menopause	Lungs
		
//angina	Angina	Men's Health
//benign_prostatic_hyperplasia	Benign Prostatic Hyperplasia (BPH)	Men's Health
//impotence_ed	Erectile Dysfunction (Impotence)	Men's Health
//baldness	Hair Loss (Baldness)	Men's Health
//prostate_cancer	Prostate Cancer	Men's Health
//prostatitis	Prostatitis	Men's Health
//sexually_transmitted_diseases_stds_in_men	Sexually Transmitted Diseases	Men's Health
//testicular_cancer	Testicular Cancer	Men's Health
//vasectomy	Vasectomy	Men's Health
//sildenafil	Viagra	Men's Health
		
//anxiety	Anxiety	Mental Health
//body_dysmorphic_disorder	Body Dysmorphic Disorder	Mental Health
//panic_disorder	Panic Attacks	Mental Health
//postpartum_depression	Postpartum Depression	Mental Health
//separation_anxiety	Separation Anxiety	Mental Health
//stress	Stress	Mental Health
		
//    Cluster Headaches	Migraine
//    Headache	Migraine
//    Tension Headache	Migraine
		
//bone_density_scan	Bone Density	Osteoporosis
//estradiol	Estradiol	Osteoporosis
//hormone_therapy	Hormone Replacement Therapy	Osteoporosis
//menopause	Menopause	Osteoporosis
//osteoporosis	Osteoporosis	Osteoporosis
		
//attention_deficit_hyperactivity_disorder_adhd	Attention Deficit Disorder (ADD)	Pediatrics / Healthy Kids
//bedwetting	Bedwetting	Pediatrics / Healthy Kids
//birth_defects	Birth Defects	Pediatrics / Healthy Kids
//chickenpox_varicella	Chickenpox	Pediatrics / Healthy Kids
//colic	Colic	Pediatrics / Healthy Kids
//diaper_rash	Diaper Rash	Pediatrics / Healthy Kids
//lactose_intolerance	Lactose Intolerance	Pediatrics / Healthy Kids
//nosebleed	Nosebleeds	Pediatrics / Healthy Kids
//pink_eye	Pink Eye	Pediatrics / Healthy Kids
//measles_rubeola	Measles	Pediatrics / Healthy Kids
//mumps	Mumps	Pediatrics / Healthy Kids
//tonsillectomy	Tonsillectomy	Pediatrics / Healthy Kids
		
//arthroscopy	Arthroscopy	Rheumatoid Arthritis
//celecoxib	Celebrex	Rheumatoid Arthritis
//cortisone_injection	Cortisone Injection	Rheumatoid Arthritis
//infliximab	Remicade	Rheumatoid Arthritis
//rheumatoid_arthritis	Rheumatoid Arthritis	Rheumatoid Arthritis
//total_hip_replacement	Total Hip Replacement	Rheumatoid Arthritis
//total_knee_replacement	Total Knee Replacement	Rheumatoid Arthritis
		
//alzheimers_disease	Alzheimer's Disease	Senior Health
//anemia	Anemia	Senior Health
//angina	Angina	Senior Health
//cataracts	Cataracts	Senior Health
//dementia	Dementia	Senior Health
//glaucoma	Glaucoma	Senior Health
//macular_degeneration_age-related_type	Macular Degeneration	Senior Health
//hair_loss	Hearing Loss	Senior Health
//heart_attack_and_atherosclerosis_prevention	Heart Attack	Senior Health
//sleep	Sleep Disturbance	Senior Health
//stroke	Stroke	Senior Health
		
//acne	Acne	Skin
//actinic_keratosis	Actinic Keratosis	Skin
//atopic_dermatitis	Atopic Dermatitis (Eczema)	Skin
//boils	Boils	Skin
//bruises	Bumps and Bruises	Skin
//burns	Burns	Skin
//seborrhea	Dandruff	Skin
//hives	Hives	Skin
//itch	Itch	Skin
//keloid	Keloid	Skin
//melanoma	Melanoma	Skin
//fungal_nails	Nail Fungus	Skin
//poison_ivy	Poison Ivy	Skin
//psoriasis	Psoriasis	Skin
//rash/index.htm	Rash (Dermatitis)	Skin
//rosacea	Rosacea	Skin
//scleroderma	Scleroderma	Skin
//shingles	Shingles	Skin
//skin_cancer	Skin Cancer	Skin
//warts_common_warts	Warts	Skin
//wrinkles	Wrinkles	Skin
		
//insomnia	Insomnia	Sleep
//jet_lag	Jet Lag	Sleep
//narcolepsy	Narcolepsy	Sleep
//sleep	Sleep	Sleep
//sleep_apnea	Sleep Apnea	Sleep
//somnoplasty	Snoring (Somnoplasty)	Sleep
		
//hashimotos_thyroiditis	Hashimoto's Thyroiditis	Thyroid
//hyperthyroidism	Hyperthyroidism	Thyroid
//hypothyroidism	Hypothyroidism	Thyroid
//levothyroxine_sodium	Synthroid (levothyroxine sodium)	Thyroid
//thyroid_cancer	Thyroid Cancer	Thyroid
//thyroid_nodules	Thyroid Nodules	Thyroid
		
//bladder_infection	Bladder Infection	Urology
//bladder_spasms	Bladder Spasms	Urology
//blood_in_urine	Blood In Urine (Hematuria)	Urology
//cystinuria	Cystinuria	Urology
//interstitial_cystitis	Interstitial Cystitis	Urology
//kidney_stone	Kidney Stone	Urology
//nerve_disease_and_bladder_control	Nerve Disease and Bladder Control	Urology
//overactive_bladder	Overactive Bladder	Urology
//prostatitis	Prostatitis	Urology
//urethral_stricture	Urethral Stricture	Urology
//urinalysis	Urinalysis	Urology
//urinary_retention	Urinary Retention	Urology
//urine_infection	Urinary Tract Infections	Urology
		
//anorexia_nervosa	Anorexia Nervosa	Weight Loss
//bulimia	Bulimia	Weight Loss
//cellulite	Cellulite	Weight Loss
//childhood_obesity	Childhood Obesity	Weight Loss
		
//birth_control	Birth Control	Women's Health
//breast_cancer	Breast Cancer	Women's Health
//breastfeeding	Breastfeeding	Women's Health
//hormone_therapy	Hormone Therapy	Women's Health
//hysterectomy	Hysterectomy	Women's Health
//menopause	Menopause	Women's Health
//miscarriage	Miscarriage	Women's Health
//osteoporosis	Osteoporosis	Women's Health
//ovarian_cancer	Ovarian Cancer	Women's Health
//ovarian_cysts	Ovarian Cysts	Women's Health
//premenstrual_syndrome	PMS (Premenstrual Syndrome)	Women's Health
//sexually_transmitted_diseases_stds_in_women	Sexually Transmitted Diseases (STDs)	Women's Health
//uterine_cancer	Uterine Cancer	Women's Health
//varicose_veins	Varicose Veins	Women's Health
//yeast_vaginitis	Yeast Infections	Women's Health



// -----------------------------------------------------------------


//        Migraine headaches
//Seizures or convulsions
//Stroke
//Polio
//Glaucoma
//Cataracts
//Blindness
//Recurrent ear infections
//Deafness
//Hay fever, allergic nose
//Recurrent sinusitis
//Asthma
//Chronic bronchitis
//Emphysema
//Tuberculosis
//Heart murmur
//Heart attack
//Angina
//Enlarged heart
//Rheumatic fever
//High blood pressure
//Hiatal hernia / Chronic heartburn
//Stomach or duodenal ulcer
//Hepatitis
//Cirrhosis
//Gall stones
//Colon or bowel trouble
//Dysentery or serious diarrhea
//Rectal trouble
//Hemorrihoids
//Recurrent urinary infections
//Kidney stones
//Other kidney disease
//Arthri