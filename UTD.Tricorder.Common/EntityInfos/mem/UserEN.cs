using System;
using System.Collections.Generic;
using Framework.Common;
using UTD.Tricorder.Common.EntityObjects;
using UTD.Tricorder.Common.ServiceInterfaces;

namespace UTD.Tricorder.Common.EntityInfos
{
	public class UserEN : EntityInfoBase
	{
	
		#region Generator-Safe Area
		//Please write your properties and functions here. This part will not be replaced.

        public const string AdditionalData_Approve = "Approve";
        public const string AdditionalData_SearchFromVisitBook = "SearchFromVisitBook";
        public const string AdditionalData_ProfileEdit = "ProfileEdit";

        public const string Action_Approve = "Approve";
        public const string Action_Reject = "Reject";
        public const string Action_Lock = "Lock";
        public const string Action_UnLock = "UnLock";
        public const string Action_ChangePasswordAdmin = "ChangePasswordAdmin";



        protected override void InitAdditionalDataKey(string entityName, string additionalDataKey)
        {
            base.InitAdditionalDataKey(entityName, additionalDataKey);

            if (additionalDataKey == AdditionalData_Approve)
            {
                this.ActionsList.Add(new EntityAction() { Name = UserEN.Action_Approve, Caption = "Approve", Icon= FIcon.ThumbUp });
                this.ActionsList.Add(new EntityAction() { Name = UserEN.Action_Reject, Caption = "Reject", Icon = FIcon.ThumbDown });
                this.DefaultFilter = new FilterExpression(new Filter(vUser.ColumnNames.UserApprovalStatusID, EntityEnums.UserApprovalStatusEnum.WaitingForApproval));


                this.EntityColumns[vUser.ColumnNames.LastLoginDate].GridVisible = false;
                this.EntityColumns[vUser.ColumnNames.LastLoginDate].PickListVisible = false;
                this.EntityColumns[vUser.ColumnNames.LastPasswordChangedDate].GridVisible = false;
                this.EntityColumns[vUser.ColumnNames.LastPasswordChangedDate].PickListVisible = false;
                this.EntityColumns[vUser.ColumnNames.FailedPasswordAttemptCount].GridVisible = false;
                this.EntityColumns[vUser.ColumnNames.FailedPasswordAttemptCount].PickListVisible = false;
                this.EntityColumns[vUser.ColumnNames.UserApprovalStatusTitle].GridVisible = false;
                this.EntityColumns[vUser.ColumnNames.UserApprovalStatusTitle].PickListVisible = false;
            }
            else
            {
                this.ActionsList.Add(new EntityAction() { Name = UserEN.Action_Lock, Caption = "Lock", Icon = FIcon.Lock });
                this.ActionsList.Add(new EntityAction() { Name = UserEN.Action_UnLock, Caption = "Unlock", Icon = FIcon.LockOpen });
                this.ActionsList.Add(new EntityAction() { Name = UserEN.Action_ChangePasswordAdmin, Caption = "Change Password", Icon = FIcon.TextfieldKey });
            }

            //hiding important columns
            this.EntityColumns[vUser.ColumnNames.PasswordHash].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.PasswordHash].PickListVisible = false;
            this.EntityColumns[vUser.ColumnNames.PasswordSalt].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.PasswordSalt].PickListVisible = false;

            this.EntityColumns[vUser.ColumnNames.RoleCode].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.RoleCode].PickListVisible = false;
            this.EntityColumns[vUser.ColumnNames.UserApprovalStatusCode].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.UserApprovalStatusCode].PickListVisible = false;
            this.EntityColumns[vUser.ColumnNames.InsertUserID].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.InsertUserID].PickListVisible = false;

            this.EntityColumns[vUser.ColumnNames.MembershipAreaCode].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.MembershipAreaCode].PickListVisible = false;
            this.EntityColumns[vUser.ColumnNames.MembershipAreaName].GridVisible = false;
            this.EntityColumns[vUser.ColumnNames.MembershipAreaName].PickListVisible = false;

            // set readonly fields in edit form
            this.EntityColumns[vUser.ColumnNames.UserApprovalStatusID].EditFormIsReadOnly = true;
            this.EntityColumns[vUser.ColumnNames.ApprovalUserID].EditFormIsReadOnly = true;
            this.EntityColumns[vUser.ColumnNames.LastLoginDate].EditFormIsReadOnly = true;
            this.EntityColumns[vUser.ColumnNames.LastPasswordChangedDate].EditFormIsReadOnly = true;
            this.EntityColumns[vUser.ColumnNames.LastStatusChangeDate].EditFormIsReadOnly = true;
            this.EntityColumns[vUser.ColumnNames.FailedPasswordAttemptCount].EditFormIsReadOnly = true;
            this.EntityColumns[vUser.ColumnNames.DefaultRoleID].EditFormIsReadOnly = true;

            // set hidden fields in edit form
            this.EntityColumns[vUser.ColumnNames.LastLoginDate].EditFormIsHidden = true;
            this.EntityColumns[vUser.ColumnNames.LastPasswordChangedDate].EditFormIsHidden = true;
            this.EntityColumns[vUser.ColumnNames.LastStatusChangeDate].EditFormIsHidden = true;
            this.EntityColumns[vUser.ColumnNames.FailedPasswordAttemptCount].EditFormIsHidden = true;
            this.EntityColumns[vUser.ColumnNames.DefaultRoleID].EditFormIsHidden = true;


            this.DetailEntities.Add(new EntityDetail() { EntityName = vPerson.EntityName, 
                                                        AdditionalData = "", 
                                                        EditType = DetailEntityTabViewEnum.EditForm, 
                                                        RelatedColumnName = vPerson.ColumnNames.PersonID,
                                                        TabTitle = "Personal Info"
                                                        });

            this.DetailEntities.Add(new EntityDetail() { EntityName = vUserInRole.EntityName, 
                                                         AdditionalData = "", 
                                                         EditType = DetailEntityTabViewEnum.Default, 
                                                         RelatedColumnName = vUserInRole.ColumnNames.UserID,
                                                         TabTitle = "Roles"
                                                        });

            this.EntityColumns[vUser.ColumnNames.PhoneNumber].Caption = "Cell Phone Number";
            this.EntityColumns[vUser.ColumnNames.PhoneNumber].EditorControl = EditorControlTypes.PhoneNumberE164TextBox;
            this.EntityColumns[vUser.ColumnNames.Email].EditorControl = EditorControlTypes.EmailTextBox;
            this.EntityColumns[vUser.ColumnNames.UserName].EditorControl = EditorControlTypes.UserNameTextBox;

            // Security columns setting
            ServerOnlyColumns.Add(vUser.ColumnNames.PasswordHash);
            ServerOnlyColumns.Add(vUser.ColumnNames.PasswordSalt);
            ServerOnlyColumns.Add(vUser.ColumnNames.EmailVerificationCode);
            ServerOnlyColumns.Add(vUser.ColumnNames.PhoneVerificationCode);
            ServerOnlyColumns.Add(vUser.ColumnNames.FailedPasswordAttemptCount);
            ServerOnlyColumns.Add(vUser.ColumnNames.ResetPasswordCode);
            ServerOnlyColumns.Add(vUser.ColumnNames.ResetPasswordRequestDate);
        }

		#endregion
		
		public override void Initialize(string entityName, string additionalDataKey)
        {
            base.Initialize(entityName, additionalDataKey);


				this.EntityColumns.Add(vUser.ColumnNames.UserID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UserID,
								Caption=new i18nText("Common.ENInfo.User.UserID.Caption", "User"),
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=true, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=true,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=false,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.UserName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UserName,
								Caption=new i18nText("Common.ENInfo.User.UserName.Caption", "User Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=true,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=true,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=true,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.FirstName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.FirstName,
								Caption=new i18nText("Common.ENInfo.User.FirstName.Caption", "First Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.LastName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.LastName,
								Caption=new i18nText("Common.ENInfo.User.LastName.Caption", "Last Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.PasswordHash,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.PasswordHash,
								Caption=new i18nText("Common.ENInfo.User.PasswordHash.Caption", "Password Hash"),
								DataTypeDotNet=typeof(byte[]), 
								ValidationMaxLength= 64,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.FileUploader, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.PasswordSalt,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.PasswordSalt,
								Caption=new i18nText("Common.ENInfo.User.PasswordSalt.Caption", "Password Salt"),
								DataTypeDotNet=typeof(byte[]), 
								ValidationMaxLength= 64,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.FileUploader, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.Email,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.Email,
								Caption=new i18nText("Common.ENInfo.User.Email.Caption", "Email"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.PhoneNumber,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.PhoneNumber,
								Caption=new i18nText("Common.ENInfo.User.PhoneNumber.Caption", "Phone Number"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 18,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.UserApprovalStatusID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UserApprovalStatusID,
								Caption=new i18nText("Common.ENInfo.User.UserApprovalStatusID.Caption", "User Approval Status"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUserApprovalStatus.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUserApprovalStatus.ColumnNames.UserApprovalStatusID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.ApprovalUserID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.ApprovalUserID,
								Caption=new i18nText("Common.ENInfo.User.ApprovalUserID.Caption", "Approval User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUser.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUser.ColumnNames.UserID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.MembershipAreaID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.MembershipAreaID,
								Caption=new i18nText("Common.ENInfo.User.MembershipAreaID.Caption", "Membership Area"),
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vMembershipArea.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vMembershipArea.ColumnNames.MembershipAreaID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.InsertUserID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.InsertUserID,
								Caption=new i18nText("Common.ENInfo.User.InsertUserID.Caption", "Insert User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUser.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUser.ColumnNames.UserID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.InsertDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.InsertDate,
								Caption=new i18nText("Common.ENInfo.User.InsertDate.Caption", "Insert Date"),
								DataTypeDotNet=typeof(DateTime), 
								ValidationMaxLength= 27,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.UpdateUserID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UpdateUserID,
								Caption=new i18nText("Common.ENInfo.User.UpdateUserID.Caption", "Update User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUser.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUser.ColumnNames.UserID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.UpdateDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UpdateDate,
								Caption=new i18nText("Common.ENInfo.User.UpdateDate.Caption", "Update Date"),
								DataTypeDotNet=typeof(DateTime?), 
								ValidationMaxLength= 27,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.LastLoginDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.LastLoginDate,
								Caption=new i18nText("Common.ENInfo.User.LastLoginDate.Caption", "Last Login Date"),
								DataTypeDotNet=typeof(DateTime?), 
								ValidationMaxLength= 27,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.DatePicker, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.LastPasswordChangedDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.LastPasswordChangedDate,
								Caption=new i18nText("Common.ENInfo.User.LastPasswordChangedDate.Caption", "Last Password Changed Date"),
								DataTypeDotNet=typeof(DateTime), 
								ValidationMaxLength= 27,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.DatePicker, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.LastStatusChangeDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.LastStatusChangeDate,
								Caption=new i18nText("Common.ENInfo.User.LastStatusChangeDate.Caption", "Last Status Change Date"),
								DataTypeDotNet=typeof(DateTime), 
								ValidationMaxLength= 27,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.DatePicker, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.FailedPasswordAttemptCount,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.FailedPasswordAttemptCount,
								Caption=new i18nText("Common.ENInfo.User.FailedPasswordAttemptCount.Caption", "Failed Password Attempt Count"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.NumericTextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.MembershipAreaName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.MembershipAreaName,
								Caption=new i18nText("Common.ENInfo.User.MembershipAreaName.Caption", "Membership Area Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.MembershipAreaCode,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.MembershipAreaCode,
								Caption=new i18nText("Common.ENInfo.User.MembershipAreaCode.Caption", "Membership Area Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.DefaultRoleID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.DefaultRoleID,
								Caption=new i18nText("Common.ENInfo.User.DefaultRoleID.Caption", "Default Role"),
								DataTypeDotNet=typeof(long), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vRole.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vRole.ColumnNames.RoleID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.RoleName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.RoleName,
								Caption=new i18nText("Common.ENInfo.User.RoleName.Caption", "Role Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.RoleCode,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.RoleCode,
								Caption=new i18nText("Common.ENInfo.User.RoleCode.Caption", "Role Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.UserApprovalStatusTitle,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UserApprovalStatusTitle,
								Caption=new i18nText("Common.ENInfo.User.UserApprovalStatusTitle.Caption", "User Approval Status Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.UserApprovalStatusCode,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.UserApprovalStatusCode,
								Caption=new i18nText("Common.ENInfo.User.UserApprovalStatusCode.Caption", "User Approval Status Code"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 50,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.EmailVerificationCode,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.EmailVerificationCode,
								Caption=new i18nText("Common.ENInfo.User.EmailVerificationCode.Caption", "Email Verification Code"),
								DataTypeDotNet=typeof(Guid), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.PhoneVerificationCode,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.PhoneVerificationCode,
								Caption=new i18nText("Common.ENInfo.User.PhoneVerificationCode.Caption", "Phone Verification Code"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.NumericTextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.IsEmailVerified,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.IsEmailVerified,
								Caption=new i18nText("Common.ENInfo.User.IsEmailVerified.Caption", "Is Email Verified"),
								DataTypeDotNet=typeof(bool), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.CheckBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.IsPhoneVerified,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.IsPhoneVerified,
								Caption=new i18nText("Common.ENInfo.User.IsPhoneVerified.Caption", "Is Phone Verified"),
								DataTypeDotNet=typeof(bool), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.CheckBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.NamePrefix,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.NamePrefix,
								Caption=new i18nText("Common.ENInfo.User.NamePrefix.Caption", "Name Prefix"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 4,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.PrimaryLanguageID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.PrimaryLanguageID,
								Caption=new i18nText("Common.ENInfo.User.PrimaryLanguageID.Caption", "Primary Language"),
								DataTypeDotNet=typeof(short), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vLanguage.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vLanguage.ColumnNames.LanguageID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.MiddleName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.MiddleName,
								Caption=new i18nText("Common.ENInfo.User.MiddleName.Caption", "Middle Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 100,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.TextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.WorldTimeZoneTitle,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.WorldTimeZoneTitle,
								Caption=new i18nText("Common.ENInfo.User.WorldTimeZoneTitle.Caption", "World Time Zone Title"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 1000,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.WorldTimeZoneIANAName,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.WorldTimeZoneIANAName,
								Caption=new i18nText("Common.ENInfo.User.WorldTimeZoneIANAName.Caption", "World Time Zone I A N A Name"),
								DataTypeDotNet=typeof(string), 
								ValidationMaxLength= 1000,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.None, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=false,
								IsUpdatable=false,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.WorldTimeZoneID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.WorldTimeZoneID,
								Caption=new i18nText("Common.ENInfo.User.WorldTimeZoneID.Caption", "World Time Zone"),
								DataTypeDotNet=typeof(short), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vWorldTimeZone.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vWorldTimeZone.ColumnNames.WorldTimeZoneID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.ReferrerUserID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.ReferrerUserID,
								Caption=new i18nText("Common.ENInfo.User.ReferrerUserID.Caption", "Referrer User"),
								DataTypeDotNet=typeof(long?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vUser.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vUser.ColumnNames.UserID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.ResetPasswordCode,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.ResetPasswordCode,
								Caption=new i18nText("Common.ENInfo.User.ResetPasswordCode.Caption", "Reset Password Code"),
								DataTypeDotNet=typeof(int?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.NumericTextBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.ResetPasswordRequestDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.ResetPasswordRequestDate,
								Caption=new i18nText("Common.ENInfo.User.ResetPasswordRequestDate.Caption", "Reset Password Request Date"),
								DataTypeDotNet=typeof(DateTime?), 
								ValidationMaxLength= 0,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.DatePicker, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.IsOnline,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.IsOnline,
								Caption=new i18nText("Common.ENInfo.User.IsOnline.Caption", "Is Online"),
								DataTypeDotNet=typeof(bool), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.CheckBox, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.LastOnlineDate,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.LastOnlineDate,
								Caption=new i18nText("Common.ENInfo.User.LastOnlineDate.Caption", "Last Online Date"),
								DataTypeDotNet=typeof(DateTime?), 
								ValidationMaxLength= 27,
								ValidationIsNullable = true, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.DatePicker, 
								IsPrimaryKey=false, 
								IsForeignKey=false, 
								ForeignEntityName="",
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName="",
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=true,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			
				this.EntityColumns.Add(vUser.ColumnNames.InsertSiteID,
                new ColumnInfo() { 
								Name= vUser.ColumnNames.InsertSiteID,
								Caption=new i18nText("Common.ENInfo.User.InsertSiteID.Caption", "Insert Site"),
								DataTypeDotNet=typeof(int), 
								ValidationMaxLength= 0,
								ValidationIsNullable = false, 
								ValidationMinValue = null,
								ValidationMaxValue = null,
								ValidationNoDuplicate = false,
								EditorControl= EditorControlTypes.ComboBox, 
								IsPrimaryKey=false, 
								IsForeignKey=true, 
								ForeignEntityName=vSite.EntityName,
                                ForeignEntityAdditionalDataKey="",
                                ForeignEntityMapColumnName=vSite.ColumnNames.SiteID,
								IsClientColumn=false,
								IsInsertable=true,
								IsUpdatable=true,
								PickListVisible=false,
								GridAllowFilter=true,
								GridColumnSize=100,
								GridIsInplaceEditable=false,
								GridVisible=false,
								GridIsAutoExpand=false,
								GridTextAlign = TextAlignEnum.Default
						});
			

            this.EntityTitle = "User";
            this.IDFieldName = "UserID";
            this.CodeFieldName = "";
            this.TitleFieldName = "UserName";

            this.Schema = "mem";

			this.InitAdditionalDataKey(entityName, additionalDataKey);
			
        }
		
		
        /////////////////////////// Static access methods ////////////////////////

        /// <summary>
        /// Gets entity service from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <param name="additionalDataKey">additional data key. it can be empty</param>
        /// <returns>Entity service</returns>
		public static IUserService GetService(string additionalDataKey = "")
		{
			return (IUserService) EntityFactory.GetEntityServiceByName(vUser.EntityName, additionalDataKey);
		}

        /// <summary>
        /// Gets entity object for table from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static User GetEntityObjectT()
		{
			return (User)EntityFactory.GetEntityObject(vUser.EntityName, GetSourceTypeEnum.Table);
		}
		
        /// <summary>
        /// Gets entity object for view from its factory
        /// This method only simplifies the factory calls
        /// </summary>
        /// <returns>Entity object</returns>
		public static vUser GetEntityObjectV()
		{
			return (vUser)EntityFactory.GetEntityObject(vUser.EntityName, GetSourceTypeEnum.View);
		}


	}
}

