var ControllerDebug = {
    DoctorFormNew: function ($scope) {
        var model = $scope.model;
        model.Degrees = 'General physician';
        model.ProfessionalStatement = 'A sample personal statement';
        model.RegistrationNumber = '234234234234';
        model.LicenseNumbers = '23r2342424, 232983482';
        model.DefaultVisitPrice = '1000';
        model.ClinicAddress = '75080 User Address, user street';
        model.BoardCertificationYear = 2012;
        model.MedicalSchool = 'my medical school';
        model.ResidencyPlace = 'A residency place';
        //model.HospitalPrivileges = true;
        model.HasRevokedLicense = true;
        model.HasMilitaryExperience = true;
        model.FederalDEAInformation = 'Federal DEA information';
    }, // end DoctorFormNew

    PersonFormNew: function ($scope) {
        var model = $scope.model;
        model.GenderTypeID = 0;
        model.Birthday = '1984/12/12';
        model.CountryID = 'IR';
        model.AddressLine1 = 'Address Line 1';
        model.AddressLine2 = 'Address Line 2';
        model.NonUSStateTitle = 'My State';
        model.City = 'Dallas';
        model.ZipCode = '75080';
    }, // end PersonFormNew


    PatientInsuranceFormNew: function ($scope) {
        //var model = $scope.model;
        //model.SubscriberName = "Mohammad Ali Ghaderi";
        //model.GroupNumber = "Group2";
        //model.BenefitIdentifier = "Benefit identifier value";
        //model.InsuranceCoNumber = "88838439";
        //model.CoPayAmount = 20039;
        //model.IsPrimary = true;
        //model.InsuranceID = 290;
        //model.InsurancePlanID = 6316;

    }, // end PatientInsuranceFormNew

    PersonFormNew: function ($scope) {
        var model = $scope.model;
        model.Birthday = "2014/12/12";
        model.GenderTypeID = 1;
        model.AddressLine1 = "2648 Custer Pkwy";
        model.AddressLine2 = "";
        model.USStateID = 'TX';
        model.NonUSStateTitle = "";
        model.City = "Richardson";
        model.ZipCode = "75080";
        model.CountryID = "US";
    } // end PersonFormNew


} // end controllerdebug

