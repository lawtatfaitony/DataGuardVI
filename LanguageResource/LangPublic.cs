using LanguageResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageResource
{
    public class Lang
    {
        #region  多语言资源
		 
				 ///<summary>忘記密碼 ？</summary>
				public static string Account_LoginViewModel_ForgetPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "忘记密码 ？";
								 case "zh-HK":
									 return "忘記密碼 ？";
								  case "en-US":
									 return "Forget Password ？";
 								 
 								 default:									 
									 return "Forget Password ？";
							} 
 					}
				}
		 
				 ///<summary>用戶登錄</summary>
				public static string Account_LoginViewModel_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用户登录";
								 case "zh-HK":
									 return "用戶登錄";
								  case "en-US":
									 return "Login";
 								 
 								 default:									 
									 return "Login";
							} 
 					}
				} 

				 ///<summary>補假申請</summary>
				public static string ApplyLeaveAddNew_ResonAppend
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "补假申请";
								 case "zh-HK":
									 return "補假申請";
								  case "en-US":
									 return "Compensatory Leave Application";
 								 
 								 default:									 
									 return "Compensatory Leave Application";
							} 
 					}
				}
		 

				 ///<summary>需要填入考勤編號和姓名</summary>
				public static string ApprovedLeave_RequiredEmployee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "需要填入考勤编号和姓名";
								 case "zh-HK":
									 return "需要填入考勤編號和姓名";
								  case "en-US":
									 return "Required Employee ID and Name";
 								 
 								 default:									 
									 return "Required Employee ID and Name";
							} 
 					}
				}
		 
				 ///<summary>請假審批</summary>
				public static string ApprovedLeave_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假审批";
								 case "zh-HK":
									 return "請假審批";
								  case "en-US":
									 return "Approved Leave";
 								 
 								 default:									 
									 return "Approved Leave";
							} 
 					}
				}


				 ///<summary>已審核</summary>
				public static string ApprovedMode_IsApproved
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已审核";
								 case "zh-HK":
									 return "已審核";
								  case "en-US":
									 return "Is approved";
 								 
 								 default:									 
									 return "Is approved";
							} 
 					}
				}


				 ///<summary>未審核</summary>
				public static string ApprovedMode_NotApproved
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "未审核";
								 case "zh-HK":
									 return "未審核";
								  case "en-US":
									 return "Not approved";
 								 
 								 default:									 
									 return "Not approved";
							} 
 					}
				}


				 ///<summary>拒絕</summary>
				public static string ApprovedMode_Rejected
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "拒绝";
								 case "zh-HK":
									 return "拒絕";
								  case "en-US":
									 return "Rejected";
 								 
 								 default:									 
									 return "Rejected";
							} 
 					}
				}


				 ///<summary>添加身份驗證器應用</summary>
				public static string AspNetUser_AddAuthenticatorApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "添加身份验证器应用";
								 case "zh-HK":
									 return "添加身份驗證器應用";
								  case "en-US":
									 return "Add authenticator app";
 								 
 								 default:									 
									 return "Add authenticator app";
							} 
 					}
				}


				 ///<summary>身份驗證器應用</summary>
				public static string AspNetUser_AuthenticatorApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "身份验证器应用";
								 case "zh-HK":
									 return "身份驗證器應用";
								  case "en-US":
									 return "Authenticator App";
 								 
 								 default:									 
									 return "Authenticator App";
							} 
 					}
				}


				 ///<summary>用戶設置變更</summary>
				public static string AspNetUser_ChangeAccountSettings
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用户设置变更";
								 case "zh-HK":
									 return "用戶設置變更";
								  case "en-US":
									 return "Change your account settings";
 								 
 								 default:									 
									 return "Change your account settings";
							} 
 					}
				}


				 ///<summary>改變郵箱</summary>
				public static string AspNetUser_ChangeEmail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "改??箱";
								 case "zh-HK":
									 return "改變郵箱";
								  case "en-US":
									 return "Change Email";
 								 
 								 default:									 
									 return "Change Email";
							} 
 					}
				}


				 ///<summary>修改密碼</summary>
				public static string AspNetUser_ChangePassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "修改密码";
								 case "zh-HK":
									 return "修改密碼";
								  case "en-US":
									 return "Password";
 								 
 								 default:									 
									 return "Password";
							} 
 					}
				}


				 ///<summary>請檢查您的電子郵件以重置密碼。</summary>
				public static string AspNetUser_CheckEmailToReset
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请检查您的电子邮件以重置密码。";
								 case "zh-HK":
									 return "請檢查您的電子郵件以重置密碼。";
								  case "en-US":
									 return "Please check your email to reset your password.";
 								 
 								 default:									 
									 return "Please check your email to reset your password.";
							} 
 					}
				}


				 ///<summary>點擊此處確認您的帳戶</summary>
				public static string AspNetUser_ClickHereToComfirmYourAC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "点击此处确认您的帐户";
								 case "zh-HK":
									 return "點擊此處確認您的帳戶";
								  case "en-US":
									 return "Click here to confirm your account";
 								 
 								 default:									 
									 return "Click here to confirm your account";
							} 
 					}
				}


				 ///<summary>點擊此處登錄</summary>
				public static string AspNetUser_ClickHereToLogin
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "点击此处登录";
								 case "zh-HK":
									 return "點擊此處登錄";
								  case "en-US":
									 return "click here to log in";
 								 
 								 default:									 
									 return "click here to log in";
							} 
 					}
				}


				 ///<summary>配置身份驗證器應用</summary>
				public static string AspNetUser_ConfigureAuthenticatorApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Configure authenticator app";
								 case "zh-HK":
									 return "配置身份驗證器應用";
								  case "en-US":
									 return "Configure authenticator app";
 								 
 								 default:									 
									 return "Configure authenticator app";
							} 
 					}
				}


				 ///<summary>確認密碼</summary>
				public static string AspNetUser_ConfirmPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认密码";
								 case "zh-HK":
									 return "確認密碼";
								  case "en-US":
									 return "Confirm Password";
 								 
 								 default:									 
									 return "Confirm Password";
							} 
 					}
				}


				 ///<summary>刪除個人資料</summary>
				public static string AspNetUser_DeletePersonalDataTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "删除个人资料";
								 case "zh-HK":
									 return "刪除個人資料";
								  case "en-US":
									 return "Delete Personal Data";
 								 
 								 default:									 
									 return "Delete Personal Data";
							} 
 					}
				}


				 ///<summary>禁用兩因素身份驗證（2FA）</summary>
				public static string AspNetUser_DisableTwoFactorAuthentication
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "禁用两因素身份验证（2FA）";
								 case "zh-HK":
									 return "禁用兩因素身份驗證（2FA）";
								  case "en-US":
									 return "Disable Two-Factor Authentication(2FA)";
 								 
 								 default:									 
									 return "Disable Two-Factor Authentication(2FA)";
							} 
 					}
				}


				 ///<summary>禁用2FA不會更改身份驗證器應用程序中使用的密鑰。 如果您想更改密鑰（在身份驗證器應用中使用），則應</summary>
				public static string AspNetUser_DisableTwoFactorAuthenticationDesc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "禁用2FA不会更改身份验证器应用程序中使用的密钥。 如果您想更改密钥（在身份验证器应用中使用），则应";
								 case "zh-HK":
									 return "禁用2FA不會更改身份驗證器應用程序中使用的密鑰。 如果您想更改密鑰（在身份驗證器應用中使用），則應";
								  case "en-US":
									 return "Disabling 2FA does not change the keys used in authenticator apps. If you wish to change the key，used in an authenticator app you should";
 								 
 								 default:									 
									 return "Disabling 2FA does not change the keys used in authenticator apps. If you wish to change the key，used in an authenticator app you should";
							} 
 					}
				}


				 ///<summary>此操作僅禁用2FA。</summary>
				public static string AspNetUser_DisableTwoFactorAuthenticationTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "此操作仅禁用2FA。";
								 case "zh-HK":
									 return "此操作僅禁用2FA。";
								  case "en-US":
									 return "This action only disables 2FA.";
 								 
 								 default:									 
									 return "This action only disables 2FA.";
							} 
 					}
				}


				 ///<summary>下载两因素身份验证器应用程序，例如适用於Android和iOS的Microsoft Authenticator或适用於Android和iOS的Google Authenticator。</summary>
				public static string AspNetUser_Download2FaAuthenticatorApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下载两因素身份验证器应用程序，例如适用於Android和iOS的Microsoft Authenticator或适用於Android和iOS的Google Authenticator。";
								 case "zh-HK":
									 return "下载两因素身份验证器应用程序，例如适用於Android和iOS的Microsoft Authenticator或适用於Android和iOS的Google Authenticator。";
								  case "en-US":
									 return "Download a two-factor authenticator app like Microsoft Authenticator for Android and iOS or Google Authenticator for Android and iOS.";
 								 
 								 default:									 
									 return "Download a two-factor authenticator app like Microsoft Authenticator for Android and iOS or Google Authenticator for Android and iOS.";
							} 
 					}
				}


				 ///<summary>Email</summary>
				public static string AspNetUser_Email
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email";
								 case "zh-HK":
									 return "Email";
								  case "en-US":
									 return "Email";
 								 
 								 default:									 
									 return "Email";
							} 
 					}
				}


				 ///<summary>Email格式不正確</summary>
				public static string AspNetUser_Email_IsNotValid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email格式不正确";
								 case "zh-HK":
									 return "Email格式不正確";
								  case "en-US":
									 return "Email is Not valid";
 								 
 								 default:									 
									 return "Email is Not valid";
							} 
 					}
				}


				 ///<summary>請先登錄你郵箱，進行電子郵件驗證確認。</summary>
				public static string AspNetUser_EmailComfirmedIsRequired
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先登录你邮箱，进行电子邮件验证确认。";
								 case "zh-HK":
									 return "請先登錄你郵箱，進行電子郵件驗證確認。";
								  case "en-US":
									 return "Please log in to your mailbox first to confirm the email verification.";
 								 
 								 default:									 
									 return "Please log in to your mailbox first to confirm the email verification.";
							} 
 					}
				}


				 ///<summary>輸入你的電子郵箱。</summary>
				public static string AspNetUser_EnterYourEmail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?入你的?子?箱。";
								 case "zh-HK":
									 return "輸入你的電子郵箱。";
								  case "en-US":
									 return "Enter your email.";
 								 
 								 default:									 
									 return "Enter your email.";
							} 
 					}
				}


				 ///<summary>忘記這個瀏覽器</summary>
				public static string AspNetUser_ForgetThisBrowser
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "忘?????器";
								 case "zh-HK":
									 return "忘記這個瀏覽器";
								  case "en-US":
									 return "Forget this browser";
 								 
 								 default:									 
									 return "Forget this browser";
							} 
 					}
				}


				 ///<summary>忘記密碼了嗎？</summary>
				public static string AspNetUser_ForgotYourPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "忘?密?了?？";
								 case "zh-HK":
									 return "忘記密碼了嗎？";
								  case "en-US":
									 return "Forgot your password?";
 								 
 								 default:									 
									 return "Forgot your password?";
							} 
 					}
				}


				 ///<summary>生成兩因素身份驗證（2FA）恢復代碼</summary>
				public static string AspNetUser_GenRecoveryCodes
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "生成?因素身份??（2FA）恢复代?";
								 case "zh-HK":
									 return "生成兩因素身份驗證（2FA）恢復代碼";
								  case "en-US":
									 return "Generate two-factor authentication (2FA) recovery codes";
 								 
 								 default:									 
									 return "Generate two-factor authentication (2FA) recovery codes";
							} 
 					}
				}


				 ///<summary>你已經生成新的恢復授權碼</summary>
				public static string AspNetUser_GenRecoveryCodesSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "你已经生成新的恢复授权码";
								 case "zh-HK":
									 return "你已經生成新的恢復授權碼";
								  case "en-US":
									 return "You have generated new recovery codes.";
 								 
 								 default:									 
									 return "You have generated new recovery codes.";
							} 
 					}
				}


				 ///<summary>無效的登錄嘗試</summary>
				public static string AspNetUser_InvalidLoginAttempt
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?效的登???";
								 case "zh-HK":
									 return "無效的登錄嘗試";
								  case "en-US":
									 return "Invalid login attempt";
 								 
 								 default:									 
									 return "Invalid login attempt";
							} 
 					}
				}


				 ///<summary>您的登錄信息受身份驗證器應用程序的保護。 在下面輸入您的驗證碼。</summary>
				public static string AspNetUser_LoginWith2faTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "您的登?信息受身份??器?用程序的保?。 在下面?入您的???。";
								 case "zh-HK":
									 return "您的登錄信息受身份驗證器應用程序的保護。 在下面輸入您的驗證碼。";
								  case "en-US":
									 return "Your login is protected with an authenticator app. Enter your authenticator code below.";
 								 
 								 default:									 
									 return "Your login is protected with an authenticator app. Enter your authenticator code below.";
							} 
 					}
				}


				 ///<summary>使用恢復碼登錄</summary>
				public static string AspNetUser_LoginWithRecoveryCode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "使用恢复码登录";
								 case "zh-HK":
									 return "使用恢復碼登錄";
								  case "en-US":
									 return "log in with a recovery code";
 								 
 								 default:									 
									 return "log in with a recovery code";
							} 
 					}
				}


				 ///<summary>用戶帳戶被鎖定。</summary>
				public static string AspNetUser_LogOutTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用???被?定。";
								 case "zh-HK":
									 return "用戶帳戶被鎖定。";
								  case "en-US":
									 return "User account locked out.";
 								 
 								 default:									 
									 return "User account locked out.";
							} 
 					}
				}


				 ///<summary>郵箱賬號維護</summary>
				public static string AspNetUser_ManageEmail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "邮箱账号维护";
								 case "zh-HK":
									 return "郵箱賬號維護";
								  case "en-US":
									 return "Manage Email";
 								 
 								 default:									 
									 return "Manage Email";
							} 
 					}
				}


				 ///<summary>個人用戶管理</summary>
				public static string AspNetUser_ManageUrAccount
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "个人用户管理";
								 case "zh-HK":
									 return "個人用戶管理";
								  case "en-US":
									 return "Manage your account";
 								 
 								 default:									 
									 return "Manage your account";
							} 
 					}
				}


				 ///<summary>新密碼</summary>
				public static string AspNetUser_NawPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新密码";
								 case "zh-HK":
									 return "新密碼";
								  case "en-US":
									 return "New Password";
 								 
 								 default:									 
									 return "New Password";
							} 
 					}
				}


				 ///<summary>新密碼</summary>
				public static string AspNetUser_NewPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新密码";
								 case "zh-HK":
									 return "新密碼";
								  case "en-US":
									 return "New Password";
 								 
 								 default:									 
									 return "New Password";
							} 
 					}
				}


				 ///<summary>無法訪問您的身份驗證器設備？ 您可以</summary>
				public static string AspNetUser_NoAuthenticatorDeviceTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无法访问您的身份验证器设备？ 您可以";
								 case "zh-HK":
									 return "無法訪問您的身份驗證器設備？ 您可以";
								  case "en-US":
									 return "Dont have access to your authenticator device? You can";
 								 
 								 default:									 
									 return "Dont have access to your authenticator device? You can";
							} 
 					}
				}


				 ///<summary>舊密碼</summary>
				public static string AspNetUser_OldPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "旧密码";
								 case "zh-HK":
									 return "舊密碼";
								  case "en-US":
									 return "Old Password";
 								 
 								 default:									 
									 return "Old Password";
							} 
 					}
				}


				 ///<summary>Password</summary>
				public static string AspNetUser_Password
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Password";
								 case "zh-HK":
									 return "Password";
								  case "en-US":
									 return "Password";
 								 
 								 default:									 
									 return "Password";
							} 
 					}
				}


				 ///<summary>密碼不符合規則、格式</summary>
				public static string AspNetUser_PasswordFormatReuired
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "密码不符合规则、格式";
								 case "zh-HK":
									 return "密碼不符合規則、格式";
								  case "en-US":
									 return "Password is not format reuired";
 								 
 								 default:									 
									 return "Password is not format reuired";
							} 
 					}
				}


				 ///<summary>密碼不匹配</summary>
				public static string AspNetUser_PasswordNotMatch
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "密?不匹配";
								 case "zh-HK":
									 return "密碼不匹配";
								  case "en-US":
									 return "Password Not Match";
 								 
 								 default:									 
									 return "Password Not Match";
							} 
 					}
				}


				 ///<summary>個人資料</summary>
				public static string AspNetUser_PersonalData
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "个人资料";
								 case "zh-HK":
									 return "個人資料";
								  case "en-US":
									 return "Personal Data";
 								 
 								 default:									 
									 return "Personal Data";
							} 
 					}
				}


				 ///<summary>刪除此數據將永久刪除您的帳戶，并且無法恢復。（聯系管理員）</summary>
				public static string AspNetUser_PersonProfileDelete
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "删除此数据将永久删除您的帐户，并且无法恢复。（联系管理员）";
								 case "zh-HK":
									 return "刪除此數據將永久刪除您的帳戶，并且無法恢復。（聯系管理員）";
								  case "en-US":
									 return "Deleting this data will permanently remove your account, and this cannot be recovered.(contact administrator).";
 								 
 								 default:									 
									 return "Deleting this data will permanently remove your account, and this cannot be recovered.(contact administrator).";
							} 
 					}
				}


				 ///<summary>您的帳戶包含您提供給我們的個人數據。 此頁面允許您下載或刪除該數據。</summary>
				public static string AspNetUser_PersonProfileDesc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "您的帐户包含您提供给我们的个人数据。 此页面允许您下载或删除该数据。";
								 case "zh-HK":
									 return "您的帳戶包含您提供給我們的個人數據。 此頁面允許您下載或刪除該數據。";
								  case "en-US":
									 return "Your account contains personal data that you have given us. This page allows you to download or delete that data.";
 								 
 								 default:									 
									 return "Your account contains personal data that you have given us. This page allows you to download or delete that data.";
							} 
 					}
				}


				 ///<summary>手機號碼格式不正確</summary>
				public static string AspNetUser_PhoneNumber_IsNotValid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手机号码格式不正确";
								 case "zh-HK":
									 return "手機號碼格式不正確";
								  case "en-US":
									 return "PhoneNumber is Not valid";
 								 
 								 default:									 
									 return "PhoneNumber is Not valid";
							} 
 					}
				}


				 ///<summary>用戶資料</summary>
				public static string AspNetUser_Profile
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用户资料";
								 case "zh-HK":
									 return "用戶資料";
								  case "en-US":
									 return "Profile";
 								 
 								 default:									 
									 return "Profile";
							} 
 					}
				}


				 ///<summary>刪除數據并關閉我的帳戶</summary>
				public static string AspNetUser_ProfileDeleteAndClosed
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "删除数据并关闭我的帐户";
								 case "zh-HK":
									 return "刪除數據并關閉我的帳戶";
								  case "en-US":
									 return "Delete data and close my account";
 								 
 								 default:									 
									 return "Delete data and close my account";
							} 
 					}
				}


				 ///<summary>注冊確認</summary>
				public static string AspNetUser_RegisterConfirmation
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注册确认";
								 case "zh-HK":
									 return "注冊確認";
								  case "en-US":
									 return "Register confirmation";
 								 
 								 default:									 
									 return "Register confirmation";
							} 
 					}
				}


				 ///<summary>重置身份驗證器</summary>
				public static string AspNetUser_ResetAuthenticator
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "重置身份验证器";
								 case "zh-HK":
									 return "重置身份驗證器";
								  case "en-US":
									 return "Reset authenticator key.";
 								 
 								 default:									 
									 return "Reset authenticator key.";
							} 
 					}
				}


				 ///<summary>重置身份驗證器應用</summary>
				public static string AspNetUser_ResetAuthenticatorApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "重置身份??器?用";
								 case "zh-HK":
									 return "重置身份驗證器應用";
								  case "en-US":
									 return "Reset authenticator app";
 								 
 								 default:									 
									 return "Reset authenticator app";
							} 
 					}
				}


				 ///<summary>如果您重置身份驗證器密鑰，那麼您的身份驗證器應用程序將無法工作，直到您對其進行重新配置。</summary>
				public static string AspNetUser_ResetAuthenticatorDesc1
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "如果您重置身份验证器密钥，那麽您的身份验证器应用程序将无法工作，直到您对其进行重新配置。";
								 case "zh-HK":
									 return "如果您重置身份驗證器密鑰，那麼您的身份驗證器應用程序將無法工作，直到您對其進行重新配置。";
								  case "en-US":
									 return "If you reset your authenticator key your authenticator app will not work until you reconfigure it.";
 								 
 								 default:									 
									 return "If you reset your authenticator key your authenticator app will not work until you reconfigure it.";
							} 
 					}
				}


				 ///<summary>在您驗證身份驗證器應用程序之前，此過程將禁用2FA。如果您未完成身份驗證器應用程序配置，則可能會失去對帳戶的訪問權限。</summary>
				public static string AspNetUser_ResetAuthenticatorDesc2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "在您验证身份验证器应用程序之前，此过程将禁用2FA。如果您未完成身份验证器应用程序配置，则可能会失去对帐户的访问权限。";
								 case "zh-HK":
									 return "在您驗證身份驗證器應用程序之前，此過程將禁用2FA。如果您未完成身份驗證器應用程序配置，則可能會失去對帳戶的訪問權限。";
								  case "en-US":
									 return "This process disables 2FA until you verify your authenticator app.If you do not complete your authenticator app configuration you may lose access to your account.";
 								 
 								 default:									 
									 return "This process disables 2FA until you verify your authenticator app.If you do not complete your authenticator app configuration you may lose access to your account.";
							} 
 					}
				}


				 ///<summary>重置身份驗證器密鑰</summary>
				public static string AspNetUser_ResetAuthenticatorKey
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "重置身份验证器密钥";
								 case "zh-HK":
									 return "重置身份驗證器密鑰";
								  case "en-US":
									 return "Reset authenticator key";
 								 
 								 default:									 
									 return "Reset authenticator key";
							} 
 					}
				}


				 ///<summary>要使用身份驗證器應用，請執行以下步驟：</summary>
				public static string AspNetUser_ResetAuthenticatorStep123
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "要使用身份验证器应用，请执行以下步骤：";
								 case "zh-HK":
									 return "要使用身份驗證器應用，請執行以下步驟：";
								  case "en-US":
									 return "To use an authenticator app go through the following steps:";
 								 
 								 default:									 
									 return "To use an authenticator app go through the following steps:";
							} 
 					}
				}


				 ///<summary>您的身份驗證器應用程序密鑰已被重置，您將需要使用新密鑰來配置身份驗證器應用程序。</summary>
				public static string AspNetUser_ResetAuthenticatorTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "您的身份验证器应用程序密钥已被重置，您将需要使用新密钥来配置身份验证器应用程序。";
								 case "zh-HK":
									 return "您的身份驗證器應用程序密鑰已被重置，您將需要使用新密鑰來配置身份驗證器應用程序。";
								  case "en-US":
									 return "Your authenticator app key has been reset, you will need to configure your authenticator app using the new key.";
 								 
 								 default:									 
									 return "Your authenticator app key has been reset, you will need to configure your authenticator app using the new key.";
							} 
 					}
				}


				 ///<summary>您的密碼已重置。 請</summary>
				public static string AspNetUser_ResetPasswordSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "您的密码已重置。 请";
								 case "zh-HK":
									 return "您的密碼已重置。 請";
								  case "en-US":
									 return "Your password has been reset. Please";
 								 
 								 default:									 
									 return "Your password has been reset. Please";
							} 
 					}
				}


				 ///<summary>重置你的密碼</summary>
				public static string AspNetUser_ResetYourPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "重置你的密?";
								 case "zh-HK":
									 return "重置你的密碼";
								  case "en-US":
									 return "Reset your password";
 								 
 								 default:									 
									 return "Reset your password";
							} 
 					}
				}


				 ///<summary>掃描QR碼或將此鍵<kbd>{0}</kbd>輸入到您的兩因素身份驗證器應用中。 空格和大小寫無關緊要。</summary>
				public static string AspNetUser_ScanQRcodeOrEnterKey
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "扫描QR码或将此键<kbd>{0}</kbd>输入到您的两因素身份验证器应用中。 空格和大小写无关紧要。";
								 case "zh-HK":
									 return "掃描QR碼或將此鍵<kbd>{0}</kbd>輸入到您的兩因素身份驗證器應用中。 空格和大小寫無關緊要。";
								  case "en-US":
									 return "Scan the QR Code or enter this key<kbd>{0}</kbd>into your two factor authenticator app. Spaces and casing do not matter.";
 								 
 								 default:									 
									 return "Scan the QR Code or enter this key<kbd>{0}</kbd>into your two factor authenticator app. Spaces and casing do not matter.";
							} 
 					}
				}


				 ///<summary>一旦您掃描了QR碼或輸入了上面的密鑰，您的兩因素身份驗證應用程序將為您提供唯一的代碼。 在下面的確認框中輸入代碼。</summary>
				public static string AspNetUser_ScanQRcodeOrEnterKeyAndNext
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "一旦您扫描了QR码或输入了上面的密钥，您的两因素身份验证应用程序将为您提供唯一的代码。 在下面的确认框中输入代码。";
								 case "zh-HK":
									 return "一旦您掃描了QR碼或輸入了上面的密鑰，您的兩因素身份驗證應用程序將為您提供唯一的代碼。 在下面的確認框中輸入代碼。";
								  case "en-US":
									 return "Once you have scanned the QR code or input the key above, your two factor authentication app will provide you with a unique code. Enter the code in the confirmation box below.";
 								 
 								 default:									 
									 return "Once you have scanned the QR code or input the key above, your two factor authentication app will provide you with a unique code. Enter the code in the confirmation box below.";
							} 
 					}
				}


				 ///<summary>發送驗證郵件</summary>
				public static string AspNetUser_SendVerificationEmail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "发送验证邮件";
								 case "zh-HK":
									 return "發送驗證郵件";
								  case "en-US":
									 return "Send verification email";
 								 
 								 default:									 
									 return "Send verification email";
							} 
 					}
				}


				 ///<summary>設置密碼</summary>
				public static string AspNetUser_SetPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置密码";
								 case "zh-HK":
									 return "設置密碼";
								  case "en-US":
									 return "Set Password";
 								 
 								 default:									 
									 return "Set Password";
							} 
 					}
				}


				 ///<summary>您沒有此站點的本地用戶名/密碼。 添加本地帳戶，以便無需外部登錄即可登錄。</summary>
				public static string AspNetUser_SetPasswordTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "您没有此站点的本地用户名/密码。 添加本地帐户，以便无需外部登录即可登录。";
								 case "zh-HK":
									 return "您沒有此站點的本地用戶名/密碼。 添加本地帳戶，以便無需外部登錄即可登錄。";
								  case "en-US":
									 return "You do not have a local username/password for this site. Add a local account so you can log in without an external login.";
 								 
 								 default:									 
									 return "You do not have a local username/password for this site. Add a local account so you can log in without an external login.";
							} 
 					}
				}


				 ///<summary>設置身份驗證器應用</summary>
				public static string AspNetUser_SetupAuthenticatorApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?置身份??器?用";
								 case "zh-HK":
									 return "設置身份驗證器應用";
								  case "en-US":
									 return "Setup authenticator app";
 								 
 								 default:									 
									 return "Setup authenticator app";
							} 
 					}
				}


				 ///<summary>雙因子認證</summary>
				public static string AspNetUser_TwoFactorAuthentication
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?因子??";
								 case "zh-HK":
									 return "雙因子認證";
								  case "en-US":
									 return "Two-Factor Authentication";
 								 
 								 default:									 
									 return "Two-Factor Authentication";
							} 
 					}
				}


				 ///<summary>雙因子驗證碼</summary>
				public static string AspNetUser_TwoFactorCode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "双因子验证码";
								 case "zh-HK":
									 return "雙因子驗證碼";
								  case "en-US":
									 return "Two Factor Code";
 								 
 								 default:									 
									 return "Two Factor Code";
							} 
 					}
				}


				 ///<summary>密碼更新</summary>
				public static string AspNetUser_UpdatePassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "密码更新";
								 case "zh-HK":
									 return "密碼更新";
								  case "en-US":
									 return "Update Password";
 								 
 								 default:									 
									 return "Update Password";
							} 
 					}
				}


				 ///<summary>UserName必須是數字和字母組合</summary>
				public static string AspNetUser_UserName_IsNotValid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "UserName必须是数字和字母组合";
								 case "zh-HK":
									 return "UserName必須是數字和字母組合";
								  case "en-US":
									 return "UserName must combine into Digits and Letter within length of 5-30";
 								 
 								 default:									 
									 return "UserName must combine into Digits and Letter within length of 5-30";
							} 
 					}
				}


				 ///<summary>驗證碼</summary>
				public static string AspNetUser_VerificationCode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "验证码";
								 case "zh-HK":
									 return "驗證碼";
								  case "en-US":
									 return "Verification Code";
 								 
 								 default:									 
									 return "Verification Code";
							} 
 					}
				}


				 ///<summary>驗證</summary>
				public static string AspNetUser_Verify
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "验证";
								 case "zh-HK":
									 return "驗證";
								  case "en-US":
									 return "Verify";
 								 
 								 default:									 
									 return "Verify";
							} 
 					}
				}


				 ///<summary>您的密碼已被更改。</summary>
				public static string AspNetUser_YourPasswordChanged
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "您的密码已被更改。";
								 case "zh-HK":
									 return "您的密碼已被更改。";
								  case "en-US":
									 return "Your password has been changed.";
 								 
 								 default:									 
									 return "Your password has been changed.";
							} 
 					}
				}


				 ///<summary>嘗試登錄</summary>
				public static string AspNetUsers_AccessFailedCount
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "尝试登录";
								 case "zh-HK":
									 return "嘗試登錄";
								  case "en-US":
									 return "Access Failed Count";
 								 
 								 default:									 
									 return "Access Failed Count";
							} 
 					}
				}


				 ///<summary>Email</summary>
				public static string AspNetUsers_Email
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email";
								 case "zh-HK":
									 return "Email";
								  case "en-US":
									 return "Email";
 								 
 								 default:									 
									 return "Email";
							} 
 					}
				}


				 ///<summary>Email 确认</summary>
				public static string AspNetUsers_EmailConfirmed
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email 确认";
								 case "zh-HK":
									 return "Email 确认";
								  case "en-US":
									 return "Email Confirmed";
 								 
 								 default:									 
									 return "Email Confirmed";
							} 
 					}
				}


				 ///<summary>通過Email重置忘記的密碼</summary>
				public static string AspNetUsers_ForGotPasswordByEmail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "通?Email重置忘?的密?";
								 case "zh-HK":
									 return "通過Email重置忘記的密碼";
								  case "en-US":
									 return "ForGot Password By Email";
 								 
 								 default:									 
									 return "ForGot Password By Email";
							} 
 					}
				}


				 ///<summary>ID</summary>
				public static string AspNetUsers_ID
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ID";
								 case "zh-HK":
									 return "ID";
								  case "en-US":
									 return "ID";
 								 
 								 default:									 
									 return "ID";
							} 
 					}
				}


				 ///<summary>IndustryId</summary>
				public static string AspNetUsers_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "IndustryId";
								 case "zh-HK":
									 return "IndustryId";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>登出鎖定</summary>
				public static string AspNetUsers_LockoutEnabled
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登出锁定";
								 case "zh-HK":
									 return "登出鎖定";
								  case "en-US":
									 return "Lockout Enabled";
 								 
 								 default:									 
									 return "Lockout Enabled";
							} 
 					}
				}


				 ///<summary>MainComId</summary>
				public static string AspNetUsers_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "MainComId";
								 case "zh-HK":
									 return "MainComId";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>手機號碼</summary>
				public static string AspNetUsers_PhoneNumber
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手机号码";
								 case "zh-HK":
									 return "手機號碼";
								  case "en-US":
									 return "Phone";
 								 
 								 default:									 
									 return "Phone";
							} 
 					}
				}


				 ///<summary>手機確認</summary>
				public static string AspNetUsers_PhoneNumberConfirmed
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手机确认";
								 case "zh-HK":
									 return "手機確認";
								  case "en-US":
									 return "Phone Confirmed";
 								 
 								 default:									 
									 return "Phone Confirmed";
							} 
 					}
				}


				 ///<summary>系統用戶ID</summary>
				public static string AspNetUsers_UserID
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统用户ID";
								 case "zh-HK":
									 return "系統用戶ID";
								  case "en-US":
									 return "Sys UserID";
 								 
 								 default:									 
									 return "Sys UserID";
							} 
 					}
				}


				 ///<summary>用戶名稱</summary>
				public static string AspNetUsers_UserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用户名称";
								 case "zh-HK":
									 return "用戶名稱";
								  case "en-US":
									 return "User Name";
 								 
 								 default:									 
									 return "User Name";
							} 
 					}
				}


				 ///<summary>ID</summary>
				public static string AttendanceByDay_AttendanceByDayId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ID";
								 case "zh-HK":
									 return "ID";
								  case "en-US":
									 return "ID";
 								 
 								 default:									 
									 return "ID";
							} 
 					}
				}


				 ///<summary>系統計算周期類型</summary>
				public static string AttendanceByDay_CalcPeriodType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统计算周期类型";
								 case "zh-HK":
									 return "系統計算周期類型";
								  case "en-US":
									 return "CalcPeriodType";
 								 
 								 default:									 
									 return "CalcPeriodType";
							} 
 					}
				}


				 ///<summary>合約商ID</summary>
				public static string AttendanceByDay_ContractorId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "合约商ID";
								 case "zh-HK":
									 return "合約商ID";
								  case "en-US":
									 return "ContractorId";
 								 
 								 default:									 
									 return "ContractorId";
							} 
 					}
				}


				 ///<summary>合約商</summary>
				public static string AttendanceByDay_ContractorName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "合约商";
								 case "zh-HK":
									 return "合約商";
								  case "en-US":
									 return "Contractor";
 								 
 								 default:									 
									 return "Contractor";
							} 
 					}
				}


				 ///<summary>總早退時長</summary>
				public static string AttendanceByDay_DayEarlyOutTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "总早退時長";
								 case "zh-HK":
									 return "總早退時長";
								  case "en-US":
									 return "EarlyOutTimeSpan";
 								 
 								 default:									 
									 return "EarlyOutTimeSpan";
							} 
 					}
				}


				 ///<summary>總遲到次</summary>
				public static string AttendanceByDay_DayIsEarlyTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "总迟到次";
								 case "zh-HK":
									 return "總遲到次";
								  case "en-US":
									 return "IsEarlyTimes";
 								 
 								 default:									 
									 return "IsEarlyTimes";
							} 
 					}
				}


				 ///<summary>總遲到次數</summary>
				public static string AttendanceByDay_DayIsLateTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "总迟到次数";
								 case "zh-HK":
									 return "總遲到次數";
								  case "en-US":
									 return "IsLateTimes";
 								 
 								 default:									 
									 return "IsLateTimes";
							} 
 					}
				}


				 ///<summary>總遲到時長</summary>
				public static string AttendanceByDay_DayLateInTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "总迟到时长";
								 case "zh-HK":
									 return "總遲到時長";
								  case "en-US":
									 return "LateInTimeSpan";
 								 
 								 default:									 
									 return "LateInTimeSpan";
							} 
 					}
				}


				 ///<summary>午夜餐總早退時長</summary>
				public static string AttendanceByDay_DayLunchEarlyOutTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐总早退时长";
								 case "zh-HK":
									 return "午夜餐總早退時長";
								  case "en-US":
									 return "LunchEarlyOutTimeSpan";
 								 
 								 default:									 
									 return "LunchEarlyOutTimeSpan";
							} 
 					}
				}


				 ///<summary>午夜餐總早退次數</summary>
				public static string AttendanceByDay_DayLunchIsEarlyTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐总早退次数";
								 case "zh-HK":
									 return "午夜餐總早退次數";
								  case "en-US":
									 return "LunchIsEarlyTimez";
 								 
 								 default:									 
									 return "LunchIsEarlyTimez";
							} 
 					}
				}


				 ///<summary>午夜餐總遲到次數</summary>
				public static string AttendanceByDay_DayLunchIsLateTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐总迟到次数";
								 case "zh-HK":
									 return "午夜餐總遲到次數";
								  case "en-US":
									 return "LunchIsLateTimes";
 								 
 								 default:									 
									 return "LunchIsLateTimes";
							} 
 					}
				}


				 ///<summary>午夜餐總遲到時長</summary>
				public static string AttendanceByDay_DayLunchLateInTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐总迟到时长";
								 case "zh-HK":
									 return "午夜餐總遲到時長";
								  case "en-US":
									 return "LunchLateInTimeSpan";
 								 
 								 default:									 
									 return "LunchLateInTimeSpan";
							} 
 					}
				}


				 ///<summary>當日午晚間遲到早退次數</summary>
				public static string AttendanceByDay_DayLunchTimeStartEndTotalTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当日午晚间迟到早退次数";
								 case "zh-HK":
									 return "當日午晚間遲到早退次數";
								  case "en-US":
									 return "Current day total times of Lunch|OT Start and end";
 								 
 								 default:									 
									 return "Current day total times of Lunch|OT Start and end";
							} 
 					}
				}


				 ///<summary>午夜餐結束漏打次數</summary>
				public static string AttendanceByDay_DayMissingLunchEndTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐结束漏打次数";
								 case "zh-HK":
									 return "午夜餐結束漏打次數";
								  case "en-US":
									 return "MissingLunchEndTimez";
 								 
 								 default:									 
									 return "MissingLunchEndTimez";
							} 
 					}
				}


				 ///<summary>午夜餐漏打次數</summary>
				public static string AttendanceByDay_DayMissingLunchStartTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐漏打次数";
								 case "zh-HK":
									 return "午夜餐漏打次數";
								  case "en-US":
									 return "MissingLunchStartTimez";
 								 
 								 default:									 
									 return "MissingLunchStartTimez";
							} 
 					}
				}


				 ///<summary>加班結束漏打次數</summary>
				public static string AttendanceByDay_DayMissingOverTimeEndTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班結束漏打次数";
								 case "zh-HK":
									 return "加班結束漏打次數";
								  case "en-US":
									 return "MissingOTEndTimez";
 								 
 								 default:									 
									 return "MissingOTEndTimez";
							} 
 					}
				}


				 ///<summary>加班開始漏打次數</summary>
				public static string AttendanceByDay_DayMissingOverTimeStartTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班開始漏打次数";
								 case "zh-HK":
									 return "加班開始漏打次數";
								  case "en-US":
									 return "MissingOTStartTimez";
 								 
 								 default:									 
									 return "MissingOTStartTimez";
							} 
 					}
				}


				 ///<summary>下班漏打次數</summary>
				public static string AttendanceByDay_DayMissingWorkOffTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班漏打次数";
								 case "zh-HK":
									 return "下班漏打次數";
								  case "en-US":
									 return "MissingWorkOffTimez";
 								 
 								 default:									 
									 return "MissingWorkOffTimez";
							} 
 					}
				}


				 ///<summary>上班漏打次數</summary>
				public static string AttendanceByDay_DayMissingWorkOnTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班漏打次数";
								 case "zh-HK":
									 return "上班漏打次數";
								  case "en-US":
									 return "MissingWorkOnTimez";
 								 
 								 default:									 
									 return "MissingWorkOnTimez";
							} 
 					}
				}


				 ///<summary>OT</summary>
				public static string AttendanceByDay_DayOverTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班";
								 case "zh-HK":
									 return "OT";
								  case "en-US":
									 return "OverTime";
 								 
 								 default:									 
									 return "OverTime";
							} 
 					}
				}


				 ///<summary>加班總早退總時長</summary>
				public static string AttendanceByDay_DayOverTimeEarlyOutTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班总早退总时长";
								 case "zh-HK":
									 return "加班總早退總時長";
								  case "en-US":
									 return "OTEarlyOutTimeSpan";
 								 
 								 default:									 
									 return "OTEarlyOutTimeSpan";
							} 
 					}
				}


				 ///<summary>加班總早退次數</summary>
				public static string AttendanceByDay_DayOverTimeIsEarlyTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班总早退次数";
								 case "zh-HK":
									 return "加班總早退次數";
								  case "en-US":
									 return "OTIsEarlyTimes";
 								 
 								 default:									 
									 return "OTIsEarlyTimes";
							} 
 					}
				}


				 ///<summary>加班總遲到次數</summary>
				public static string AttendanceByDay_DayOverTimeIsLateTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班迟到到次数";
								 case "zh-HK":
									 return "加班總遲到次數";
								  case "en-US":
									 return "OTIsLateTimes";
 								 
 								 default:									 
									 return "OTIsLateTimes";
							} 
 					}
				}


				 ///<summary>加班總遲到時長</summary>
				public static string AttendanceByDay_DayOverTimeLateInTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班总迟到时长";
								 case "zh-HK":
									 return "加班總遲到時長";
								  case "en-US":
									 return "OTLateInTimeSpan";
 								 
 								 default:									 
									 return "OTLateInTimeSpan";
							} 
 					}
				}


				 ///<summary>當日加班遲到早退次數</summary>
				public static string AttendanceByDay_DayOverTimeStartEndTotalTimez
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当日加班迟到早退次数";
								 case "zh-HK":
									 return "當日加班遲到早退次數";
								  case "en-US":
									 return "Current day total times of OT Start and end";
 								 
 								 default:									 
									 return "Current day total times of OT Start and end";
							} 
 					}
				}


				 ///<summary>考勤設置JSON</summary>
				public static string AttendanceByDay_DayShiftListJson
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤设置JSON";
								 case "zh-HK":
									 return "考勤設置JSON";
								  case "en-US":
									 return "ShiftNameJSON";
 								 
 								 default:									 
									 return "ShiftNameJSON";
							} 
 					}
				}


				 ///<summary>考勤設置列表</summary>
				public static string AttendanceByDay_DayShiftNameList
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤设置列表";
								 case "zh-HK":
									 return "考勤設置列表";
								  case "en-US":
									 return "ShiftNameList";
 								 
 								 default:									 
									 return "ShiftNameList";
							} 
 					}
				}


				 ///<summary>午夜餐總時長</summary>
				public static string AttendanceByDay_DayTotalLunchTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午夜餐总时长";
								 case "zh-HK":
									 return "午夜餐總時長";
								  case "en-US":
									 return "TotalLunchTimeSpan";
 								 
 								 default:									 
									 return "TotalLunchTimeSpan";
							} 
 					}
				}


				 ///<summary>加班總時長</summary>
				public static string AttendanceByDay_DayTotalOverTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班总时长";
								 case "zh-HK":
									 return "加班總時長";
								  case "en-US":
									 return "TotalOTSpan";
 								 
 								 default:									 
									 return "TotalOTSpan";
							} 
 					}
				}


				 ///<summary>淨工作日時長</summary>
				public static string AttendanceByDay_DayTotalWorkNetTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "净工作日時長";
								 case "zh-HK":
									 return "淨工作日時長";
								  case "en-US":
									 return "WorkNetTimeSpan";
 								 
 								 default:									 
									 return "WorkNetTimeSpan";
							} 
 					}
				}


				 ///<summary>工時</summary>
				public static string AttendanceByDay_DayTotalWorkTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工时";
								 case "zh-HK":
									 return "工時";
								  case "en-US":
									 return "TotalWorkTimeSpan";
 								 
 								 default:									 
									 return "TotalWorkTimeSpan";
							} 
 					}
				}


				 ///<summary>部門ID</summary>
				public static string AttendanceByDay_DepartmentId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门ID";
								 case "zh-HK":
									 return "部門ID";
								  case "en-US":
									 return "Depart. Id";
 								 
 								 default:									 
									 return "Depart. Id";
							} 
 					}
				}


				 ///<summary>部門名字</summary>
				public static string AttendanceByDay_DepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门名字";
								 case "zh-HK":
									 return "部門名字";
								  case "en-US":
									 return "Depart. Name";
 								 
 								 default:									 
									 return "Depart. Name";
							} 
 					}
				}


				 ///<summary>考勤ID</summary>
				public static string AttendanceByDay_EmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤ID";
								 case "zh-HK":
									 return "考勤ID";
								  case "en-US":
									 return "Employee ID";
 								 
 								 default:									 
									 return "Employee ID";
							} 
 					}
				}


				 ///<summary>考勤人員名字</summary>
				public static string AttendanceByDay_EmployeeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤人员名字";
								 case "zh-HK":
									 return "考勤人員名字";
								  case "en-US":
									 return "Employee Name";
 								 
 								 default:									 
									 return "Employee Name";
							} 
 					}
				}


				 ///<summary>假期</summary>
				public static string AttendanceByDay_Holiday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期";
								 case "zh-HK":
									 return "假期";
								  case "en-US":
									 return "Holiday";
 								 
 								 default:									 
									 return "Holiday";
							} 
 					}
				}


				 ///<summary>當天假期ID</summary>
				public static string AttendanceByDay_HolidayId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当天假期ID";
								 case "zh-HK":
									 return "當天假期ID";
								  case "en-US":
									 return "DayHolidayId";
 								 
 								 default:									 
									 return "DayHolidayId";
							} 
 					}
				}


				 ///<summary>當天假期名稱</summary>
				public static string AttendanceByDay_HolidayName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当天假期名称";
								 case "zh-HK":
									 return "當天假期名稱";
								  case "en-US":
									 return "DayHolidayName";
 								 
 								 default:									 
									 return "DayHolidayName";
							} 
 					}
				}


				 ///<summary>缺勤</summary>
				public static string AttendanceByDay_IsAbsentDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "缺勤";
								 case "zh-HK":
									 return "缺勤";
								  case "en-US":
									 return "IsAbsentDay";
 								 
 								 default:									 
									 return "IsAbsentDay";
							} 
 					}
				}


				 ///<summary>計算完成狀態</summary>
				public static string AttendanceByDay_IsCompleted
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "计算完成状态";
								 case "zh-HK":
									 return "計算完成狀態";
								  case "en-US":
									 return "IsCompleted";
 								 
 								 default:									 
									 return "IsCompleted";
							} 
 					}
				}


				 ///<summary>工作天</summary>
				public static string AttendanceByDay_IsWorkDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作天";
								 case "zh-HK":
									 return "工作天";
								  case "en-US":
									 return "IsWorkDay";
 								 
 								 default:									 
									 return "IsWorkDay";
							} 
 					}
				}


				 ///<summary>工種ID</summary>
				public static string AttendanceByDay_JobId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种ID";
								 case "zh-HK":
									 return "工種ID";
								  case "en-US":
									 return "JobId";
 								 
 								 default:									 
									 return "JobId";
							} 
 					}
				}


				 ///<summary>工種ID</summary>
				public static string AttendanceByDay_JobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种ID";
								 case "zh-HK":
									 return "工種ID";
								  case "en-US":
									 return "JobName";
 								 
 								 default:									 
									 return "JobName";
							} 
 					}
				}


				 ///<summary>請假</summary>
				public static string AttendanceByDay_Leave
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假";
								 case "zh-HK":
									 return "請假";
								  case "en-US":
									 return "Leave";
 								 
 								 default:									 
									 return "Leave";
							} 
 					}
				}


				 ///<summary>當天請假ID</summary>
				public static string AttendanceByDay_LeaveId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当天请假ID";
								 case "zh-HK":
									 return "當天請假ID";
								  case "en-US":
									 return "DayLeaveId";
 								 
 								 default:									 
									 return "DayLeaveId";
							} 
 					}
				}


				 ///<summary>請假薪酬率類型</summary>
				public static string AttendanceByDay_LeavePaidType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假薪酬率类型";
								 case "zh-HK":
									 return "請假薪酬率類型";
								  case "en-US":
									 return "LeavePaidType";
 								 
 								 default:									 
									 return "LeavePaidType";
							} 
 					}
				}


				 ///<summary>請假薪酬率類型名稱</summary>
				public static string AttendanceByDay_LeavePaidTypeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假薪酬率类型名称";
								 case "zh-HK":
									 return "請假薪酬率類型名稱";
								  case "en-US":
									 return "LeavePaidTypeName";
 								 
 								 default:									 
									 return "LeavePaidTypeName";
							} 
 					}
				}


				 ///<summary>當天請假類型</summary>
				public static string AttendanceByDay_LeaveType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当天请假类型";
								 case "zh-HK":
									 return "當天請假類型";
								  case "en-US":
									 return "DayLeaveType";
 								 
 								 default:									 
									 return "DayLeaveType";
							} 
 					}
				}


				 ///<summary>當天請假類型名稱</summary>
				public static string AttendanceByDay_LeaveTypeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?天?假?型名稱";
								 case "zh-HK":
									 return "當天請假類型名稱";
								  case "en-US":
									 return "DayLeaveTypeName";
 								 
 								 default:									 
									 return "DayLeaveTypeName";
							} 
 					}
				}


				 ///<summary>午餐/夜宵</summary>
				public static string AttendanceByDay_Lunch
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐/夜宵";
								 case "zh-HK":
									 return "午餐/夜宵";
								  case "en-US":
									 return "Lunch/Mid Night";
 								 
 								 default:									 
									 return "Lunch/Mid Night";
							} 
 					}
				}


				 ///<summary>公司ID</summary>
				public static string AttendanceByDay_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司ID";
								 case "zh-HK":
									 return "公司ID";
								  case "en-US":
									 return "Com ID";
 								 
 								 default:									 
									 return "Com ID";
							} 
 					}
				}


				 ///<summary>排班發生日期</summary>
				public static string AttendanceByDay_OccurDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班发生日期";
								 case "zh-HK":
									 return "排班發生日期";
								  case "en-US":
									 return "OccurDate";
 								 
 								 default:									 
									 return "OccurDate";
							} 
 					}
				}


				 ///<summary>記錄鎖定狀態</summary>
				public static string AttendanceByDay_OnDataLocked
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "记录锁定状态";
								 case "zh-HK":
									 return "記錄鎖定狀態";
								  case "en-US":
									 return "OnDataLocked";
 								 
 								 default:									 
									 return "OnDataLocked";
							} 
 					}
				}


				 ///<summary>日平均支付率</summary>
				public static string AttendanceByDay_OnDutyPaidRatioAvg
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日平均支付率";
								 case "zh-HK":
									 return "日平均支付率";
								  case "en-US":
									 return "PaidRatioAvg";
 								 
 								 default:									 
									 return "PaidRatioAvg";
							} 
 					}
				}


				 ///<summary>日平均工作率</summary>
				public static string AttendanceByDay_OnDutyWorkRatioAvg
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日平均工作率";
								 case "zh-HK":
									 return "日平均工作率";
								  case "en-US":
									 return "OnDutyWorkRatioAvg";
 								 
 								 default:									 
									 return "OnDutyWorkRatioAvg";
							} 
 					}
				}


				 ///<summary>職位Id</summary>
				public static string AttendanceByDay_PositionId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "职位Id";
								 case "zh-HK":
									 return "職位Id";
								  case "en-US":
									 return "Pos. Name";
 								 
 								 default:									 
									 return "Pos. Name";
							} 
 					}
				}


				 ///<summary>頭銜</summary>
				public static string AttendanceByDay_PositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "头衔";
								 case "zh-HK":
									 return "頭銜";
								  case "en-US":
									 return "Title";
 								 
 								 default:									 
									 return "Title";
							} 
 					}
				}


				 ///<summary>比率</summary>
				public static string AttendanceByDay_Ratio
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "比率";
								 case "zh-HK":
									 return "比率";
								  case "en-US":
									 return "Ratio";
 								 
 								 default:									 
									 return "Ratio";
							} 
 					}
				}


				 ///<summary>位置ID</summary>
				public static string AttendanceByDay_SiteId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置ID";
								 case "zh-HK":
									 return "位置ID";
								  case "en-US":
									 return "SiteId";
 								 
 								 default:									 
									 return "SiteId";
							} 
 					}
				}


				 ///<summary>位置名稱</summary>
				public static string AttendanceByDay_SiteName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置名称";
								 case "zh-HK":
									 return "位置名稱";
								  case "en-US":
									 return "SiteName";
 								 
 								 default:									 
									 return "SiteName";
							} 
 					}
				}


				 ///<summary>系統計算時間</summary>
				public static string AttendanceByDay_SysCalcDateTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统计算时间";
								 case "zh-HK":
									 return "系統計算時間";
								  case "en-US":
									 return "SysCalcDateTime";
 								 
 								 default:									 
									 return "SysCalcDateTime";
							} 
 					}
				}


				 ///<summary>月度排班列表</summary>
				public static string AttendanceByMonthly_ShiftNameList
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "月度排班列表";
								 case "zh-HK":
									 return "月度排班列表";
								  case "en-US":
									 return "Monthly ShiftNameList";
 								 
 								 default:									 
									 return "Monthly ShiftNameList";
							} 
 					}
				}


				 ///<summary>午/晚餐累計早退</summary>
				public static string AttendanceByPeriod_AccuEarlyLunchOutTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐累计早退";
								 case "zh-HK":
									 return "午/晚餐累計早退";
								  case "en-US":
									 return "Lunch/Night Accumulate TimeSpan Of Early Out";
 								 
 								 default:									 
									 return "Lunch/Night Accumulate TimeSpan Of Early Out";
							} 
 					}
				}


				 ///<summary>累計早退時長</summary>
				public static string AttendanceByPeriod_AccuEarlyOutTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计早退时长";
								 case "zh-HK":
									 return "累計早退時長";
								  case "en-US":
									 return "Accu EarlyOut TimeSpan";
 								 
 								 default:									 
									 return "Accu EarlyOut TimeSpan";
							} 
 					}
				}


				 ///<summary>OT累計早退</summary>
				public static string AttendanceByPeriod_AccuEarlyOverTimeOutTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OT累计早退";
								 case "zh-HK":
									 return "OT累計早退";
								  case "en-US":
									 return "Accu Times Of OverTime EarlyOut";
 								 
 								 default:									 
									 return "Accu Times Of OverTime EarlyOut";
							} 
 					}
				}


				 ///<summary>累計假期天數</summary>
				public static string AttendanceByPeriod_AccuHolidays
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计假期天数";
								 case "zh-HK":
									 return "累計假期天數";
								  case "en-US":
									 return "Accumulate Holidays";
 								 
 								 default:									 
									 return "Accumulate Holidays";
							} 
 					}
				}


				 ///<summary>累計遲到時長</summary>
				public static string AttendanceByPeriod_AccuLateInTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计迟到时长";
								 case "zh-HK":
									 return "累計遲到時長";
								  case "en-US":
									 return "Accumulate Late TimeSpan";
 								 
 								 default:									 
									 return "Accumulate Late TimeSpan";
							} 
 					}
				}


				 ///<summary>累計請假天數</summary>
				public static string AttendanceByPeriod_AccuLeaveDays
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计请假天数";
								 case "zh-HK":
									 return "累計請假天數";
								  case "en-US":
									 return "Accumulate LeaveDays";
 								 
 								 default:									 
									 return "Accumulate LeaveDays";
							} 
 					}
				}


				 ///<summary>午/晚餐累計遲到</summary>
				public static string AttendanceByPeriod_AccuLunchLateInTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐累计迟到";
								 case "zh-HK":
									 return "午/晚餐累計遲到";
								  case "en-US":
									 return "Lunch/Night Accumulate Times Of LateIn";
 								 
 								 default:									 
									 return "Lunch/Night Accumulate Times Of LateIn";
							} 
 					}
				}


				 ///<summary>累計午/夜餐時長</summary>
				public static string AttendanceByPeriod_AccuLunchTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计午/夜餐时长";
								 case "zh-HK":
									 return "累計午/夜餐時長";
								  case "en-US":
									 return "Accumulate Lunch TimeSpan";
 								 
 								 default:									 
									 return "Accumulate Lunch TimeSpan";
							} 
 					}
				}


				 ///<summary>OT累計遲到</summary>
				public static string AttendanceByPeriod_AccuOverTimeLateInTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OT累计迟到";
								 case "zh-HK":
									 return "OT累計遲到";
								  case "en-US":
									 return "Accu Times Of OverTime LateIn";
 								 
 								 default:									 
									 return "Accu Times Of OverTime LateIn";
							} 
 					}
				}


				 ///<summary>累計OT時長</summary>
				public static string AttendanceByPeriod_AccuOverTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计OT时长";
								 case "zh-HK":
									 return "累計OT時長";
								  case "en-US":
									 return "Accumulate OT TimeSpan";
 								 
 								 default:									 
									 return "Accumulate OT TimeSpan";
							} 
 					}
				}


				 ///<summary>累計早退次數</summary>
				public static string AttendanceByPeriod_AccuTimesOfEarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累?早退次?";
								 case "zh-HK":
									 return "累計早退次數";
								  case "en-US":
									 return "Accumulate Times Of EarlyOut";
 								 
 								 default:									 
									 return "Accumulate Times Of EarlyOut";
							} 
 					}
				}


				 ///<summary>累計遲到</summary>
				public static string AttendanceByPeriod_AccuTimesOfLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计迟到";
								 case "zh-HK":
									 return "累計遲到";
								  case "en-US":
									 return "Accumulate Late";
 								 
 								 default:									 
									 return "Accumulate Late";
							} 
 					}
				}


				 ///<summary>午/晚餐累計早退次數</summary>
				public static string AttendanceByPeriod_AccuTimesOfLunchEarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐累计早退次数";
								 case "zh-HK":
									 return "午/晚餐累計早退次數";
								  case "en-US":
									 return "Lunch/Night Accumulate Times Of EarlyOut";
 								 
 								 default:									 
									 return "Lunch/Night Accumulate Times Of EarlyOut";
							} 
 					}
				}


				 ///<summary>午/晚餐累計遲到次數</summary>
				public static string AttendanceByPeriod_AccuTimesOfLunchLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐累计迟到次数";
								 case "zh-HK":
									 return "午/晚餐累計遲到次數";
								  case "en-US":
									 return "Lunch/Night Accumulate Times Of LateIn";
 								 
 								 default:									 
									 return "Lunch/Night Accumulate Times Of LateIn";
							} 
 					}
				}


				 ///<summary>漏打默認</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "漏打默认";
								 case "zh-HK":
									 return "漏打默認";
								  case "en-US":
									 return "AccuTimesOfMissing";
 								 
 								 default:									 
									 return "AccuTimesOfMissing";
							} 
 					}
				}


				 ///<summary>午晚餐漏打默認結束</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissingLunchEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午晚餐漏打默认结束";
								 case "zh-HK":
									 return "午晚餐漏打默認結束";
								  case "en-US":
									 return "Accu Times Of Missing Lunch End";
 								 
 								 default:									 
									 return "Accu Times Of Missing Lunch End";
							} 
 					}
				}


				 ///<summary>午晚餐漏打開始</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissingLunchStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午晚餐默认开始";
								 case "zh-HK":
									 return "午晚餐漏打開始";
								  case "en-US":
									 return "Accu Times Of Missing Lunch Start";
 								 
 								 default:									 
									 return "Accu Times Of Missing Lunch Start";
							} 
 					}
				}


				 ///<summary>OT漏打默認結束</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissingOverTimeEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OT漏打默认结束";
								 case "zh-HK":
									 return "OT漏打默認結束";
								  case "en-US":
									 return "Accu Times Of Missing OverTime End";
 								 
 								 default:									 
									 return "Accu Times Of Missing OverTime End";
							} 
 					}
				}


				 ///<summary>OT漏打默認開始</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissingOverTimeStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OT漏打默认开始";
								 case "zh-HK":
									 return "OT漏打默認開始";
								  case "en-US":
									 return "Accu Times Of Missing OverTime Start";
 								 
 								 default:									 
									 return "Accu Times Of Missing OverTime Start";
							} 
 					}
				}


				 ///<summary>下班漏打默認</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissingWorkOff
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班漏打默认";
								 case "zh-HK":
									 return "下班漏打默認";
								  case "en-US":
									 return "Accu Times Of Missing WorkOff";
 								 
 								 default:									 
									 return "Accu Times Of Missing WorkOff";
							} 
 					}
				}


				 ///<summary>上班漏打</summary>
				public static string AttendanceByPeriod_AccuTimesOfMissingWorkOn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班漏打";
								 case "zh-HK":
									 return "上班漏打";
								  case "en-US":
									 return "Accu Times Of Missing WorkOn";
 								 
 								 default:									 
									 return "Accu Times Of Missing WorkOn";
							} 
 					}
				}


				 ///<summary>OT累計早退</summary>
				public static string AttendanceByPeriod_AccuTimesOfOverTimeEarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OT累计早退";
								 case "zh-HK":
									 return "OT累計早退";
								  case "en-US":
									 return "Accu Times Of OverTime EarlyOut";
 								 
 								 default:									 
									 return "Accu Times Of OverTime EarlyOut";
							} 
 					}
				}


				 ///<summary>OT累計早退</summary>
				public static string AttendanceByPeriod_AccuTimesOfOverTimeLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OT累计早退";
								 case "zh-HK":
									 return "OT累計早退";
								  case "en-US":
									 return "Accu Times Of OverTime LateIn";
 								 
 								 default:									 
									 return "Accu Times Of OverTime LateIn";
							} 
 					}
				}


				 ///<summary>累計調整</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegular
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计调整";
								 case "zh-HK":
									 return "累計調整";
								  case "en-US":
									 return "Accu Times Of Regular";
 								 
 								 default:									 
									 return "Accu Times Of Regular";
							} 
 					}
				}


				 ///<summary>午/晚餐調整End</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegularLunchEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐调整End";
								 case "zh-HK":
									 return "午/晚餐調整End";
								  case "en-US":
									 return "AccuTimesOfRegularLunchEnd";
 								 
 								 default:									 
									 return "AccuTimesOfRegularLunchEnd";
							} 
 					}
				}


				 ///<summary>午/晚餐調整Start</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegularLunchStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐调整Start";
								 case "zh-HK":
									 return "午/晚餐調整Start";
								  case "en-US":
									 return "AccuTimesOfRegularLunchStart";
 								 
 								 default:									 
									 return "AccuTimesOfRegularLunchStart";
							} 
 					}
				}


				 ///<summary>手動調整加班結束</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegularOverTimeEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整加班结束";
								 case "zh-HK":
									 return "手動調整加班結束";
								  case "en-US":
									 return "AccuTimesOfRegularOverTimeEnd";
 								 
 								 default:									 
									 return "AccuTimesOfRegularOverTimeEnd";
							} 
 					}
				}


				 ///<summary>手動調整加班開始</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegularOverTimeStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整加班开始";
								 case "zh-HK":
									 return "手動調整加班開始";
								  case "en-US":
									 return "AccuTimesOfRegularOverTimeStart";
 								 
 								 default:									 
									 return "AccuTimesOfRegularOverTimeStart";
							} 
 					}
				}


				 ///<summary>下班班調整次數</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegularWorkOff
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班班调整次数";
								 case "zh-HK":
									 return "下班班調整次數";
								  case "en-US":
									 return "Accu Times Of Regular WorkOff";
 								 
 								 default:									 
									 return "Accu Times Of Regular WorkOff";
							} 
 					}
				}


				 ///<summary>上班調整次數</summary>
				public static string AttendanceByPeriod_AccuTimesOfRegularWorkOn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班调整次数";
								 case "zh-HK":
									 return "上班調整次數";
								  case "en-US":
									 return "Accu Times Of Regular WorkOn";
 								 
 								 default:									 
									 return "Accu Times Of Regular WorkOn";
							} 
 					}
				}


				 ///<summary>累计工作时长</summary>
				public static string AttendanceByPeriod_AccuWorkActualNetTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计工作时长";
								 case "zh-HK":
									 return "累计工作时长";
								  case "en-US":
									 return "Accu Work lNetTime Span";
 								 
 								 default:									 
									 return "Accu Work lNetTime Span";
							} 
 					}
				}


				 ///<summary>累計工作天數</summary>
				public static string AttendanceByPeriod_AccuWorkDays
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计工作天数";
								 case "zh-HK":
									 return "累計工作天數";
								  case "en-US":
									 return "Accumulate WorkDays";
 								 
 								 default:									 
									 return "Accumulate WorkDays";
							} 
 					}
				}


				 ///<summary>累計工作時長</summary>
				public static string AttendanceByPeriod_AccuWorkTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计工作时长";
								 case "zh-HK":
									 return "累計工作時長";
								  case "en-US":
									 return "Accumulate Work TimeSpan";
 								 
 								 default:									 
									 return "Accumulate Work TimeSpan";
							} 
 					}
				}


				 ///<summary>PID</summary>
				public static string AttendanceByPeriod_AttendanceByPeriodId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "PID";
								 case "zh-HK":
									 return "PID";
								  case "en-US":
									 return "PID";
 								 
 								 default:									 
									 return "PID";
							} 
 					}
				}


				 ///<summary>考勤率</summary>
				public static string AttendanceByPeriod_AttendanceRatio
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤率";
								 case "zh-HK":
									 return "考勤率";
								  case "en-US":
									 return "AttendanceRatio";
 								 
 								 default:									 
									 return "AttendanceRatio";
							} 
 					}
				}


				 ///<summary>平均午/夜餐時長</summary>
				public static string AttendanceByPeriod_AvgLunchTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均午/夜餐时长";
								 case "zh-HK":
									 return "平均午/夜餐時長";
								  case "en-US":
									 return "Avg Lunch TimeSpan";
 								 
 								 default:									 
									 return "Avg Lunch TimeSpan";
							} 
 					}
				}


				 ///<summary>平均OT時長</summary>
				public static string AttendanceByPeriod_AvgOverTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均OT时长";
								 case "zh-HK":
									 return "平均OT時長";
								  case "en-US":
									 return "Avg OT TimeSpan";
 								 
 								 default:									 
									 return "Avg OT TimeSpan";
							} 
 					}
				}


				 ///<summary>平均凈考勤</summary>
				public static string AttendanceByPeriod_AvgWorkActualNetTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均净考勤";
								 case "zh-HK":
									 return "平均凈考勤";
								  case "en-US":
									 return "Avg Net WorkTime";
 								 
 								 default:									 
									 return "Avg Net WorkTime";
							} 
 					}
				}


				 ///<summary>平均工作時長</summary>
				public static string AttendanceByPeriod_AvgWorkTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均工作时长";
								 case "zh-HK":
									 return "平均工作時長";
								  case "en-US":
									 return "Avg Work TimeSpan";
 								 
 								 default:									 
									 return "Avg Work TimeSpan";
							} 
 					}
				}


				 ///<summary>早退</summary>
				public static string AttendanceByPeriod_EarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "早退";
								 case "zh-HK":
									 return "早退";
								  case "en-US":
									 return "Early Out";
 								 
 								 default:									 
									 return "Early Out";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string AttendanceByPeriod_EmployeeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Name";
 								 
 								 default:									 
									 return "Name";
							} 
 					}
				}


				 ///<summary>完成狀態</summary>
				public static string AttendanceByPeriod_IsCompleted
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "完成状态";
								 case "zh-HK":
									 return "完成狀態";
								  case "en-US":
									 return "IsCompleted Status";
 								 
 								 default:									 
									 return "IsCompleted Status";
							} 
 					}
				}


				 ///<summary>遲到</summary>
				public static string AttendanceByPeriod_LateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "迟到";
								 case "zh-HK":
									 return "遲到";
								  case "en-US":
									 return "LateIn";
 								 
 								 default:									 
									 return "LateIn";
							} 
 					}
				}


				 ///<summary>假期與請假</summary>
				public static string AttendanceByPeriod_LeaveAndHoliday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期与请假";
								 case "zh-HK":
									 return "假期與請假";
								  case "en-US":
									 return "Leave & Holiday";
 								 
 								 default:									 
									 return "Leave & Holiday";
							} 
 					}
				}


				 ///<summary>午晚餐遲到</summary>
				public static string AttendanceByPeriod_LunchLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午晚餐迟到";
								 case "zh-HK":
									 return "午晚餐遲到";
								  case "en-US":
									 return "Lunch/night LateIn";
 								 
 								 default:									 
									 return "Lunch/night LateIn";
							} 
 					}
				}


				 ///<summary>午晚餐</summary>
				public static string AttendanceByPeriod_LunchTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午晚餐";
								 case "zh-HK":
									 return "午晚餐";
								  case "en-US":
									 return "Lunch/Night Meal Time";
 								 
 								 default:									 
									 return "Lunch/Night Meal Time";
							} 
 					}
				}


				 ///<summary>午/晚餐</summary>
				public static string AttendanceByPeriod_LunchTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐";
								 case "zh-HK":
									 return "午/晚餐";
								  case "en-US":
									 return "Lunch/Night";
 								 
 								 default:									 
									 return "Lunch/Night";
							} 
 					}
				}


				 ///<summary>平均支付比率</summary>
				public static string AttendanceByPeriod_OnDutyPaidRatioAvg
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均支付比率";
								 case "zh-HK":
									 return "平均支付比率";
								  case "en-US":
									 return "Avg Of Paid Ratio";
 								 
 								 default:									 
									 return "Avg Of Paid Ratio";
							} 
 					}
				}


				 ///<summary>平均工作比率</summary>
				public static string AttendanceByPeriod_OnDutyWorkRatioAvg
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均工作比率";
								 case "zh-HK":
									 return "平均工作比率";
								  case "en-US":
									 return "Avg Of Work Ratio";
 								 
 								 default:									 
									 return "Avg Of Work Ratio";
							} 
 					}
				}


				 ///<summary>加班</summary>
				public static string AttendanceByPeriod_OverTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班";
								 case "zh-HK":
									 return "加班";
								  case "en-US":
									 return "OverTime";
 								 
 								 default:									 
									 return "OverTime";
							} 
 					}
				}


				 ///<summary>加班早退</summary>
				public static string AttendanceByPeriod_OverTimeEarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班早退";
								 case "zh-HK":
									 return "加班早退";
								  case "en-US":
									 return "OT EarlyOut";
 								 
 								 default:									 
									 return "OT EarlyOut";
							} 
 					}
				}


				 ///<summary>加班遲到</summary>
				public static string AttendanceByPeriod_OverTimeLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班迟到";
								 case "zh-HK":
									 return "加班遲到";
								  case "en-US":
									 return "OT LateIn";
 								 
 								 default:									 
									 return "OT LateIn";
							} 
 					}
				}


				 ///<summary>OverTime</summary>
				public static string AttendanceByPeriod_OverTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OverTime";
								 case "zh-HK":
									 return "OverTime";
								  case "en-US":
									 return "OverTime";
 								 
 								 default:									 
									 return "OverTime";
							} 
 					}
				}


				 ///<summary>周期考勤設置列表</summary>
				public static string AttendanceByPeriod_PeriodShiftNameList
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "周期考勤设置列表";
								 case "zh-HK":
									 return "周期考勤設置列表";
								  case "en-US":
									 return "Period of Shift List";
 								 
 								 default:									 
									 return "Period of Shift List";
							} 
 					}
				}


				 ///<summary>漏打計算</summary>
				public static string AttendanceByPeriod_TimesOfMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "漏打计算";
								 case "zh-HK":
									 return "漏打計算";
								  case "en-US":
									 return "TimesOfMissing";
 								 
 								 default:									 
									 return "TimesOfMissing";
							} 
 					}
				}


				 ///<summary>干預調整</summary>
				public static string AttendanceByPeriod_TimesOfRegular
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "干预调整";
								 case "zh-HK":
									 return "干預調整";
								  case "en-US":
									 return "TimesOfRegular";
 								 
 								 default:									 
									 return "TimesOfRegular";
							} 
 					}
				}


				 ///<summary>工作凈時長</summary>
				public static string AttendanceByPeriod_WorkActualNetTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作净时长";
								 case "zh-HK":
									 return "工作凈時長";
								  case "en-US":
									 return "Job Net TimeSpan";
 								 
 								 default:									 
									 return "Job Net TimeSpan";
							} 
 					}
				}


				 ///<summary>工作天</summary>
				public static string AttendanceByPeriod_WorkDays
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作天";
								 case "zh-HK":
									 return "工作天";
								  case "en-US":
									 return "WorkDays";
 								 
 								 default:									 
									 return "WorkDays";
							} 
 					}
				}


				 ///<summary>工作時長</summary>
				public static string AttendanceByPeriod_WorkTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作时长";
								 case "zh-HK":
									 return "工作時長";
								  case "en-US":
									 return "WorkTime";
 								 
 								 default:									 
									 return "WorkTime";
							} 
 					}
				}


				 ///<summary>排班ID</summary>
				public static string AttendanceByShift_AttendanceByShiftId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班ID";
								 case "zh-HK":
									 return "排班ID";
								  case "en-US":
									 return "Schedule Shift ID";
 								 
 								 default:									 
									 return "Schedule Shift ID";
							} 
 					}
				}


				 ///<summary>部門</summary>
				public static string AttendanceByShift_DepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门";
								 case "zh-HK":
									 return "部門";
								  case "en-US":
									 return "Department";
 								 
 								 default:									 
									 return "Department";
							} 
 					}
				}


				 ///<summary>早退</summary>
				public static string AttendanceByShift_EarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "早退";
								 case "zh-HK":
									 return "早退";
								  case "en-US":
									 return "EarlyOut";
 								 
 								 default:									 
									 return "EarlyOut";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string AttendanceByShift_EmployeeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Name";
 								 
 								 default:									 
									 return "Name";
							} 
 					}
				}


				 ///<summary>存在可疑的篡改記錄！！！！</summary>
				public static string AttendanceByShift_ExistDataRecruitme
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在可疑的篡改记录！！！！";
								 case "zh-HK":
									 return "存在可疑的篡改記錄！！！！";
								  case "en-US":
									 return "Exist Data Recruitme";
 								 
 								 default:									 
									 return "Exist Data Recruitme";
							} 
 					}
				}


				 ///<summary>缺勤</summary>
				public static string AttendanceByShift_IsAbsentDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "缺勤";
								 case "zh-HK":
									 return "缺勤";
								  case "en-US":
									 return "AbsentDay";
 								 
 								 default:									 
									 return "AbsentDay";
							} 
 					}
				}


				 ///<summary>漏打自動算</summary>
				public static string AttendanceByShift_IsAutoCalcMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "漏打自动算";
								 case "zh-HK":
									 return "漏打自動算";
								  case "en-US":
									 return "AutoCalcMissing";
 								 
 								 default:									 
									 return "AutoCalcMissing";
							} 
 					}
				}


				 ///<summary>上下班都是自動計算可能造成缺勤被忽略</summary>
				public static string AttendanceByShift_IsAutoCalcMissingOnOffAllTrueTip
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上下班都是自动计算可能造成缺勤被忽略";
								 case "zh-HK":
									 return "上下班都是自動計算可能造成缺勤被忽略";
								  case "en-US":
									 return "Auto calc for both of work on/off may cause absences to be ignored!";
 								 
 								 default:									 
									 return "Auto calc for both of work on/off may cause absences to be ignored!";
							} 
 					}
				}


				 ///<summary>計算完成狀態</summary>
				public static string AttendanceByShift_IsCompleted
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "计算完成状态";
								 case "zh-HK":
									 return "計算完成狀態";
								  case "en-US":
									 return "IsCompleted";
 								 
 								 default:									 
									 return "IsCompleted";
							} 
 					}
				}


				 ///<summary>早退否</summary>
				public static string AttendanceByShift_IsEarly
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "早退否";
								 case "zh-HK":
									 return "早退否";
								  case "en-US":
									 return "IsEarly";
 								 
 								 default:									 
									 return "IsEarly";
							} 
 					}
				}


				 ///<summary>遲到否</summary>
				public static string AttendanceByShift_IsLate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "迟到否";
								 case "zh-HK":
									 return "遲到否";
								  case "en-US":
									 return "IsLate";
 								 
 								 default:									 
									 return "IsLate";
							} 
 					}
				}


				 ///<summary>下班漏打自動算</summary>
				public static string AttendanceByShift_IsRegularWorkOff
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班漏打自动算";
								 case "zh-HK":
									 return "下班漏打自動算";
								  case "en-US":
									 return "RegularWorkOff";
 								 
 								 default:									 
									 return "RegularWorkOff";
							} 
 					}
				}


				 ///<summary>上班漏打自動算</summary>
				public static string AttendanceByShift_IsRegularWorkOn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班漏打自动算";
								 case "zh-HK":
									 return "上班漏打自動算";
								  case "en-US":
									 return "RegularWorkOn";
 								 
 								 default:									 
									 return "RegularWorkOn";
							} 
 					}
				}


				 ///<summary>工作天</summary>
				public static string AttendanceByShift_IsWorkDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作天";
								 case "zh-HK":
									 return "工作天";
								  case "en-US":
									 return "IsWorkDay";
 								 
 								 default:									 
									 return "IsWorkDay";
							} 
 					}
				}


				 ///<summary>工種</summary>
				public static string AttendanceByShift_JobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种";
								 case "zh-HK":
									 return "工種";
								  case "en-US":
									 return "JobName";
 								 
 								 default:									 
									 return "JobName";
							} 
 					}
				}


				 ///<summary>遲到</summary>
				public static string AttendanceByShift_LateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "迟到";
								 case "zh-HK":
									 return "遲到";
								  case "en-US":
									 return "Late";
 								 
 								 default:									 
									 return "Late";
							} 
 					}
				}


				 ///<summary>午/晚餐早退</summary>
				public static string AttendanceByShift_LunchTimeEarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐早退";
								 case "zh-HK":
									 return "午/晚餐早退";
								  case "en-US":
									 return "Lunch/Midnight EarlyOut";
 								 
 								 default:									 
									 return "Lunch/Midnight EarlyOut";
							} 
 					}
				}


				 ///<summary>午/夜餐 末</summary>
				public static string AttendanceByShift_LunchTimeEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/夜餐 末";
								 case "zh-HK":
									 return "午/夜餐 末";
								  case "en-US":
									 return "Lunch|Midnight Meal End";
 								 
 								 default:									 
									 return "Lunch|Midnight Meal End";
							} 
 					}
				}


				 ///<summary>午/晚餐遲到</summary>
				public static string AttendanceByShift_LunchTimeLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐迟到";
								 case "zh-HK":
									 return "午/晚餐遲到";
								  case "en-US":
									 return "Lunch/Midnight LateIn";
 								 
 								 default:									 
									 return "Lunch/Midnight LateIn";
							} 
 					}
				}


				 ///<summary>午/夜餐 時長</summary>
				public static string AttendanceByShift_LunchTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/夜餐 时长";
								 case "zh-HK":
									 return "午/夜餐 時長";
								  case "en-US":
									 return "Lunch/Midnight TimeSpan";
 								 
 								 default:									 
									 return "Lunch/Midnight TimeSpan";
							} 
 					}
				}


				 ///<summary>午/夜餐 始</summary>
				public static string AttendanceByShift_LunchTimeStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/夜餐 始";
								 case "zh-HK":
									 return "午/夜餐 始";
								  case "en-US":
									 return "Lunch|Midnight Meal Start";
 								 
 								 default:									 
									 return "Lunch|Midnight Meal Start";
							} 
 					}
				}


				 ///<summary>沒有可疑的篡改記錄！！！！</summary>
				public static string AttendanceByShift_NoDataRecruitment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有可疑的篡改记录！！！！";
								 case "zh-HK":
									 return "沒有可疑的篡改記錄！！！！";
								  case "en-US":
									 return "No Data Recruitment";
 								 
 								 default:									 
									 return "No Data Recruitment";
							} 
 					}
				}


				 ///<summary>薪酬比率</summary>
				public static string AttendanceByShift_OnDutyPaidRatio
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "薪酬比率";
								 case "zh-HK":
									 return "薪酬比率";
								  case "en-US":
									 return "OnDutyPaidRatio";
 								 
 								 default:									 
									 return "OnDutyPaidRatio";
							} 
 					}
				}


				 ///<summary>工作比率</summary>
				public static string AttendanceByShift_OnDutyWorkRatio
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作比率";
								 case "zh-HK":
									 return "工作比率";
								  case "en-US":
									 return "OnDutyWorkRatio";
 								 
 								 default:									 
									 return "OnDutyWorkRatio";
							} 
 					}
				}


				 ///<summary>加班早退</summary>
				public static string AttendanceByShift_OverTimeEarlyOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班早退";
								 case "zh-HK":
									 return "加班早退";
								  case "en-US":
									 return "OTEarlyOut";
 								 
 								 default:									 
									 return "OTEarlyOut";
							} 
 					}
				}


				 ///<summary>加班結束</summary>
				public static string AttendanceByShift_OverTimeEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班结束";
								 case "zh-HK":
									 return "加班結束";
								  case "en-US":
									 return "OTend";
 								 
 								 default:									 
									 return "OTend";
							} 
 					}
				}


				 ///<summary>加班早退</summary>
				public static string AttendanceByShift_OverTimeIsEarly
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班早退";
								 case "zh-HK":
									 return "加班早退";
								  case "en-US":
									 return "IsEarly";
 								 
 								 default:									 
									 return "IsEarly";
							} 
 					}
				}


				 ///<summary>加班遲到</summary>
				public static string AttendanceByShift_OverTimeIsLate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班迟到";
								 case "zh-HK":
									 return "加班遲到";
								  case "en-US":
									 return "OTIsLate";
 								 
 								 default:									 
									 return "OTIsLate";
							} 
 					}
				}


				 ///<summary>加班遲到</summary>
				public static string AttendanceByShift_OverTimeLateIn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班迟到";
								 case "zh-HK":
									 return "加班遲到";
								  case "en-US":
									 return "OTlateIn";
 								 
 								 default:									 
									 return "OTlateIn";
							} 
 					}
				}


				 ///<summary>加班時長</summary>
				public static string AttendanceByShift_OverTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班时长";
								 case "zh-HK":
									 return "加班時長";
								  case "en-US":
									 return "OTspan";
 								 
 								 default:									 
									 return "OTspan";
							} 
 					}
				}


				 ///<summary>加班開始</summary>
				public static string AttendanceByShift_OverTimeStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班开始";
								 case "zh-HK":
									 return "加班開始";
								  case "en-US":
									 return "OTstart";
 								 
 								 default:									 
									 return "OTstart";
							} 
 					}
				}


				 ///<summary>考勤日</summary>
				public static string AttendanceByShift_ScheduleDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤日";
								 case "zh-HK":
									 return "考勤日";
								  case "en-US":
									 return "Schedule";
 								 
 								 default:									 
									 return "Schedule";
							} 
 					}
				}


				 ///<summary>排班名稱</summary>
				public static string AttendanceByShift_ShiftName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班名称";
								 case "zh-HK":
									 return "排班名稱";
								  case "en-US":
									 return "Shift Name";
 								 
 								 default:									 
									 return "Shift Name";
							} 
 					}
				}


				 ///<summary>計算時間</summary>
				public static string AttendanceByShift_SysCalcDateTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "计算时间";
								 case "zh-HK":
									 return "計算時間";
								  case "en-US":
									 return "SysCalcDateTime";
 								 
 								 default:									 
									 return "SysCalcDateTime";
							} 
 					}
				}


				 ///<summary>工時長</summary>
				public static string AttendanceByShift_WorkActualNetTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工时长";
								 case "zh-HK":
									 return "工時長";
								  case "en-US":
									 return "WorkNetSpan";
 								 
 								 default:									 
									 return "WorkNetSpan";
							} 
 					}
				}


				 ///<summary>落班時間</summary>
				public static string AttendanceByShift_WorkEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班时间";
								 case "zh-HK":
									 return "落班時間";
								  case "en-US":
									 return "WorkEnd";
 								 
 								 default:									 
									 return "WorkEnd";
							} 
 					}
				}


				 ///<summary>上班時間</summary>
				public static string AttendanceByShift_WorkStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班时间";
								 case "zh-HK":
									 return "上班時間";
								  case "en-US":
									 return "WorkStart";
 								 
 								 default:									 
									 return "WorkStart";
							} 
 					}
				}


				 ///<summary>時長</summary>
				public static string AttendanceByShift_WorkTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "时长";
								 case "zh-HK":
									 return "時長";
								  case "en-US":
									 return "WorkSpan";
 								 
 								 default:									 
									 return "WorkSpan";
							} 
 					}
				}


				 ///<summary>缺勤</summary>
				public static string AttendanceDay_IsAbsentDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "缺勤";
								 case "zh-HK":
									 return "缺勤";
								  case "en-US":
									 return "IsAbsentDay";
 								 
 								 default:									 
									 return "IsAbsentDay";
							} 
 					}
				}


				 ///<summary>出入卡ID</summary>
				public static string AttendanceLog_AccesscardId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "出入卡ID";
								 case "zh-HK":
									 return "出入卡ID";
								  case "en-US":
									 return "Accesscard Id";
 								 
 								 default:									 
									 return "Accesscard Id";
							} 
 					}
				}


				 ///<summary>考勤记录ID</summary>
				public static string AttendanceLog_AttendanceLogId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤记录ID";
								 case "zh-HK":
									 return "考勤记录ID";
								  case "en-US":
									 return "Log Id";
 								 
 								 default:									 
									 return "Log Id";
							} 
 					}
				}


				 ///<summary>記錄畫面</summary>
				public static string AttendanceLog_CatchPictureFileName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "记录画面";
								 case "zh-HK":
									 return "記錄畫面";
								  case "en-US":
									 return "Catch Pic";
 								 
 								 default:									 
									 return "Catch Pic";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string AttendanceLog_CnName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "CnName";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Name";
 								 
 								 default:									 
									 return "Name";
							} 
 					}
				}


				 ///<summary>公司</summary>
				public static string AttendanceLog_CompanyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司";
								 case "zh-HK":
									 return "公司";
								  case "en-US":
									 return "Company";
 								 
 								 default:									 
									 return "Company";
							} 
 					}
				}


				 ///<summary>ContractorId</summary>
				public static string AttendanceLog_ContractorId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ContractorId";
								 case "zh-HK":
									 return "ContractorId";
								  case "en-US":
									 return "Contractor Id";
 								 
 								 default:									 
									 return "Contractor Id";
							} 
 					}
				}


				 ///<summary>合約商</summary>
				public static string AttendanceLog_ContractorName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "合约商";
								 case "zh-HK":
									 return "合約商";
								  case "en-US":
									 return "Contractor";
 								 
 								 default:									 
									 return "Contractor";
							} 
 					}
				}


				 ///<summary>創建時間</summary>
				public static string AttendanceLog_CratedDateTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "创建时间";
								 case "zh-HK":
									 return "創建時間";
								  case "en-US":
									 return "Crated Date";
 								 
 								 default:									 
									 return "Crated Date";
							} 
 					}
				}


				 ///<summary>Department Id</summary>
				public static string AttendanceLog_DepartmentId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Department Id";
								 case "zh-HK":
									 return "Department Id";
								  case "en-US":
									 return "Department Id";
 								 
 								 default:									 
									 return "Department Id";
							} 
 					}
				}


				 ///<summary>部門</summary>
				public static string AttendanceLog_DepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门";
								 case "zh-HK":
									 return "部門";
								  case "en-US":
									 return "Department";
 								 
 								 default:									 
									 return "Department";
							} 
 					}
				}


				 ///<summary>出入模式</summary>
				public static string AttendanceLog_DeviceEntryMode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "出入模式";
								 case "zh-HK":
									 return "出入模式";
								  case "en-US":
									 return "Entry Mode";
 								 
 								 default:									 
									 return "Entry Mode";
							} 
 					}
				}


				 ///<summary>设备</summary>
				public static string AttendanceLog_DeviceName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设备";
								 case "zh-HK":
									 return "设备";
								  case "en-US":
									 return "Device";
 								 
 								 default:									 
									 return "Device";
							} 
 					}
				}


				 ///<summary>雇員ID</summary>
				public static string AttendanceLog_EmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "雇员ID";
								 case "zh-HK":
									 return "雇員ID";
								  case "en-US":
									 return "EmployeeId";
 								 
 								 default:									 
									 return "EmployeeId";
							} 
 					}
				}


				 ///<summary>存在可疑的募改</summary>
				public static string AttendanceLog_ExistDataRecruitment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在可疑的募改";
								 case "zh-HK":
									 return "存在可疑的募改";
								  case "en-US":
									 return "Exist Data Recruitment";
 								 
 								 default:									 
									 return "Exist Data Recruitment";
							} 
 					}
				}


				 ///<summary>JobId</summary>
				public static string AttendanceLog_JobId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "JobId";
								 case "zh-HK":
									 return "JobId";
								  case "en-US":
									 return "JobId";
 								 
 								 default:									 
									 return "JobId";
							} 
 					}
				}


				 ///<summary>工种</summary>
				public static string AttendanceLog_JobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种";
								 case "zh-HK":
									 return "工种";
								  case "en-US":
									 return "Job Name";
 								 
 								 default:									 
									 return "Job Name";
							} 
 					}
				}


				 ///<summary>公司ID</summary>
				public static string AttendanceLog_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司ID";
								 case "zh-HK":
									 return "公司ID";
								  case "en-US":
									 return "Com Id";
 								 
 								 default:									 
									 return "Com Id";
							} 
 					}
				}


				 ///<summary>沒有可疑的募改記錄</summary>
				public static string AttendanceLog_NoDataRecruitment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有可疑的募改记录";
								 case "zh-HK":
									 return "沒有可疑的募改記錄";
								  case "en-US":
									 return "No Data Recruitment";
 								 
 								 default:									 
									 return "No Data Recruitment";
							} 
 					}
				}


				 ///<summary>記錄時間</summary>
				public static string AttendanceLog_OccurDateTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "记录时间";
								 case "zh-HK":
									 return "記錄時間";
								  case "en-US":
									 return "Occur Time";
 								 
 								 default:									 
									 return "Occur Time";
							} 
 					}
				}


				 ///<summary>日期時間范圍</summary>
				public static string AttendanceLog_occurDateTimeRange
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日期时间范围";
								 case "zh-HK":
									 return "日期時間范圍";
								  case "en-US":
									 return "Occur DateTime Range";
 								 
 								 default:									 
									 return "Occur DateTime Range";
							} 
 					}
				}


				 ///<summary>起始與結束日期時間不作搜索條件</summary>
				public static string AttendanceLog_occurDateTimeRangeTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "起始与结束日期时间不作搜索条件";
								 case "zh-HK":
									 return "起始與結束日期時間不作搜索條件";
								  case "en-US":
									 return "Start and end datetime are not search criteria";
 								 
 								 default:									 
									 return "Start and end datetime are not search criteria";
							} 
 					}
				}


				 ///<summary>Position</summary>
				public static string AttendanceLog_PositionId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "职位";
								 case "zh-HK":
									 return "Position";
								  case "en-US":
									 return "Position";
 								 
 								 default:									 
									 return "Position";
							} 
 					}
				}


				 ///<summary>职函</summary>
				public static string AttendanceLog_PositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "职函";
								 case "zh-HK":
									 return "职函";
								  case "en-US":
									 return "Position Title";
 								 
 								 default:									 
									 return "Position Title";
							} 
 					}
				}


				 ///<summary>SiteId</summary>
				public static string AttendanceLog_SiteId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "SiteId";
								 case "zh-HK":
									 return "SiteId";
								  case "en-US":
									 return "Site Id";
 								 
 								 default:									 
									 return "Site Id";
							} 
 					}
				}


				 ///<summary>位置名稱</summary>
				public static string AttendanceLog_SiteName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置名称";
								 case "zh-HK":
									 return "位置名稱";
								  case "en-US":
									 return "Site Name";
 								 
 								 default:									 
									 return "Site Name";
							} 
 					}
				}


				 ///<summary>考勤记录</summary>
				public static string AttendanceLog_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤记录";
								 case "zh-HK":
									 return "考勤记录";
								  case "en-US":
									 return "Recognization log";
 								 
 								 default:									 
									 return "Recognization log";
							} 
 					}
				}


				 ///<summary>考勤記錄報表</summary>
				public static string AttendanceLogRpt_Tilte
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤记录报表";
								 case "zh-HK":
									 return "考勤記錄報表";
								  case "en-US":
									 return "Attendance log report";
 								 
 								 default:									 
									 return "Attendance log report";
							} 
 					}
				}


				 ///<summary>實時考勤數據</summary>
				public static string AttendanceRealTime_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "实时考勤数据";
								 case "zh-HK":
									 return "實時考勤數據";
								  case "en-US":
									 return "Attendance realtime";
 								 
 								 default:									 
									 return "Attendance realtime";
							} 
 					}
				}


				 ///<summary>早退</summary>
				public static string AttendanceType_IS_EARLY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "早退";
								 case "zh-HK":
									 return "早退";
								  case "en-US":
									 return "IsEarly";
 								 
 								 default:									 
									 return "IsEarly";
							} 
 					}
				}


				 ///<summary>遲到</summary>
				public static string AttendanceType_IS_LATE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "迟到";
								 case "zh-HK":
									 return "遲到";
								  case "en-US":
									 return "IsLate";
 								 
 								 default:									 
									 return "IsLate";
							} 
 					}
				}


				 ///<summary>無記錄(可能漏打)</summary>
				public static string AttendanceType_NO_RECORD
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无记录(可能漏打)";
								 case "zh-HK":
									 return "無記錄(可能漏打)";
								  case "en-US":
									 return "NoRecord";
 								 
 								 default:									 
									 return "NoRecord";
							} 
 					}
				}


				 ///<summary>無設置</summary>
				public static string AttendanceType_NO_SETTING
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无设置";
								 case "zh-HK":
									 return "無設置";
								  case "en-US":
									 return "NoSetting";
 								 
 								 default:									 
									 return "NoSetting";
							} 
 					}
				}


				 ///<summary>正常</summary>
				public static string AttendanceType_NORMAL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "正常";
								 case "zh-HK":
									 return "正常";
								  case "en-US":
									 return "NORMAL";
 								 
 								 default:									 
									 return "NORMAL";
							} 
 					}
				}


				 ///<summary>請輸入正確的信用卡帳號格式</summary>
				public static string AttributeExtensions_CreditCardAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入正确的信用卡格式";
								 case "zh-HK":
									 return "請輸入正確的信用卡帳號格式";
								  case "en-US":
									 return "請輸入正確的信用卡帳號格式";
 								 
 								 default:									 
									 return "請輸入正確的信用卡帳號格式";
							} 
 					}
				}


				 ///<summary>必須符合数字格式 如 12-12345678-1</summary>
				public static string AttributeExtensions_CuitAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "必須符合数字格式 如 12-12345678-1";
								 case "zh-HK":
									 return "必須符合数字格式 如 12-12345678-1";
								  case "en-US":
									 return "必須符合数字格式 如 12-12345678-1";
 								 
 								 default:									 
									 return "必須符合数字格式 如 12-12345678-1";
							} 
 					}
				}


				 ///<summary>請輸入正確的日期格式</summary>
				public static string AttributeExtensions_DateAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入正确日期格式";
								 case "zh-HK":
									 return "請輸入正確的日期格式";
								  case "en-US":
									 return "請輸入正確的日期格式";
 								 
 								 default:									 
									 return "請輸入正確的日期格式";
							} 
 					}
				}


				 ///<summary>請輸入數字</summary>
				public static string AttributeExtensions_DigitsAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入数字";
								 case "zh-HK":
									 return "請輸入數字";
								  case "en-US":
									 return "Only digital";
 								 
 								 default:									 
									 return "Only digital";
							} 
 					}
				}


				 ///<summary>請輸入正確的Email格式</summary>
				public static string AttributeExtensions_EmailAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入正确的Email格式";
								 case "zh-HK":
									 return "請輸入正確的Email格式";
								  case "en-US":
									 return "Please enter the correct ema.il format";
 								 
 								 default:									 
									 return "Please enter the correct ema.il format";
							} 
 					}
				}


				 ///<summary>{0}不一致</summary>
				public static string AttributeExtensions_EqualToAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "{0}不一致";
								 case "zh-HK":
									 return "{0}不一致";
								  case "en-US":
									 return "{0}不一致";
 								 
 								 default:									 
									 return "{0}不一致";
							} 
 					}
				}


				 ///<summary>仅接受图片文件:.png,jpg,jpeg,gif</summary>
				public static string AttributeExtensions_FileExtensionsAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "仅接受文件类型:.png,jpg,jpeg,gif";
								 case "zh-HK":
									 return "仅接受图片文件:.png,jpg,jpeg,gif";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>{0}必須小於或等於{1}</summary>
				public static string AttributeExtensions_MaxAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "{0}必须小于或等于{1}";
								 case "zh-HK":
									 return "{0}必須小於或等於{1}";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>{0}必须大于{1}</summary>
				public static string AttributeExtensions_MinAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "{0}必须大于{1}";
								 case "zh-HK":
									 return "{0}必须大于{1}";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>請輸入有效的數字</summary>
				public static string AttributeExtensions_NumericAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效的数字";
								 case "zh-HK":
									 return "請輸入有效的數字";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>請輸入正確的手机号码。</summary>
				public static string AttributeExtensions_PhoneNumber
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入正确的手机号码。";
								 case "zh-HK":
									 return "請輸入正確的手机号码。";
								  case "en-US":
									 return "Please enter the correct phone number.";
 								 
 								 default:									 
									 return "Please enter the correct phone number.";
							} 
 					}
				}


				 ///<summary>輸入手機號碼格式如: 60123456</summary>
				public static string AttributeExtensions_PhoneNumberAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "输入的手机号码不正确,格式如: 13812345678";
								 case "zh-HK":
									 return "輸入手機號碼格式如: 60123456";
								  case "en-US":
									 return "Input the right phone number(e.g. : 60123456)";
 								 
 								 default:									 
									 return "Input the right phone number(e.g. : 60123456)";
							} 
 					}
				}


				 ///<summary>請輸入完整的url</summary>
				public static string AttributeExtensions_UrlAttribute_Optional_Invalid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入完整的url连接";
								 case "zh-HK":
									 return "請輸入完整的url";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>無效的url</summary>
				public static string AttributeExtensions_UrlAttribute_Protocol_Invalid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无效的URL";
								 case "zh-HK":
									 return "無效的url";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>{0} 不是有效的http,https等開頭的連接</summary>
				public static string AttributeExtensions_UrlAttribute_validHttp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效的http,https,ftp等开头的链接";
								 case "zh-HK":
									 return "{0} 不是有效的http,https等開頭的連接";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>請輸入有效的年份格式</summary>
				public static string AttributeExtensions_YearAttribute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效年份格式";
								 case "zh-HK":
									 return "請輸入有效的年份格式";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>自動計算漏打午餐結束</summary>
				public static string AutoCalcMissingType_AutoMissingLunchEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自动计算漏打午餐结束";
								 case "zh-HK":
									 return "自動計算漏打午餐結束";
								  case "en-US":
									 return "AutoCalc of Lunch End Missings";
 								 
 								 default:									 
									 return "AutoCalc of Lunch End Missings";
							} 
 					}
				}


				 ///<summary>自動計算漏打午餐開始</summary>
				public static string AutoCalcMissingType_AutoMissingLunchStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自动计算漏打午餐开始";
								 case "zh-HK":
									 return "自動計算漏打午餐開始";
								  case "en-US":
									 return "AutoCalc of Lunch Start Missings";
 								 
 								 default:									 
									 return "AutoCalc of Lunch Start Missings";
							} 
 					}
				}


				 ///<summary>加班結束時間自動算</summary>
				public static string AutoCalcMissingType_AutoMissingOverTimeEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班结束时间自动算";
								 case "zh-HK":
									 return "加班結束時間自動算";
								  case "en-US":
									 return "Auto Missing OverTime End";
 								 
 								 default:									 
									 return "Auto Missing OverTime End";
							} 
 					}
				}


				 ///<summary>加班開始時間自動算</summary>
				public static string AutoCalcMissingType_AutoMissingOverTimeStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班开始时间自动算";
								 case "zh-HK":
									 return "加班開始時間自動算";
								  case "en-US":
									 return "Auto Missing OverTime Start";
 								 
 								 default:									 
									 return "Auto Missing OverTime Start";
							} 
 					}
				}


				 ///<summary>下班漏打自動計算</summary>
				public static string AutoCalcMissingType_AutoMissingWorkOff
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班漏打自动计算";
								 case "zh-HK":
									 return "下班漏打自動計算";
								  case "en-US":
									 return "AutoCalc of Workoff  Missings";
 								 
 								 default:									 
									 return "AutoCalc of Workoff  Missings";
							} 
 					}
				}


				 ///<summary>上班漏打自動計算</summary>
				public static string AutoCalcMissingType_AutoMissingWorkOn
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班漏打自动计算";
								 case "zh-HK":
									 return "上班漏打自動計算";
								  case "en-US":
									 return "AutoCalc of Workon  Missings";
 								 
 								 default:									 
									 return "AutoCalc of Workon  Missings";
							} 
 					}
				}


				 ///<summary>手动调整午餐結束漏打</summary>
				public static string AutoCalcMissingType_ManualMissingLunchEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整午餐结束漏打";
								 case "zh-HK":
									 return "手动调整午餐結束漏打";
								  case "en-US":
									 return "Manual Missing Lunch End";
 								 
 								 default:									 
									 return "Manual Missing Lunch End";
							} 
 					}
				}


				 ///<summary>手動調整午餐開始漏打</summary>
				public static string AutoCalcMissingType_ManualMissingLunchStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整午餐开始漏打";
								 case "zh-HK":
									 return "手動調整午餐開始漏打";
								  case "en-US":
									 return "ManualMissingLunchStart";
 								 
 								 default:									 
									 return "ManualMissingLunchStart";
							} 
 					}
				}


				 ///<summary>手動調整加班結束漏打</summary>
				public static string AutoCalcMissingType_ManualMissingOvertimeEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整加班结束漏打";
								 case "zh-HK":
									 return "手動調整加班結束漏打";
								  case "en-US":
									 return "ManualMissingOvertimeEnd";
 								 
 								 default:									 
									 return "ManualMissingOvertimeEnd";
							} 
 					}
				}


				 ///<summary>手動調整加班開始漏打</summary>
				public static string AutoCalcMissingType_ManualMissingOvertimeStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整加班开始漏打";
								 case "zh-HK":
									 return "手動調整加班開始漏打";
								  case "en-US":
									 return "ManualMissingOvertimeStart";
 								 
 								 default:									 
									 return "ManualMissingOvertimeStart";
							} 
 					}
				}


				 ///<summary>手動調整下班漏打</summary>
				public static string AutoCalcMissingType_ManualWorkOffMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整下班漏打";
								 case "zh-HK":
									 return "手動調整下班漏打";
								  case "en-US":
									 return "Manual WorkOn Missing";
 								 
 								 default:									 
									 return "Manual WorkOn Missing";
							} 
 					}
				}


				 ///<summary>手動調整上班漏打</summary>
				public static string AutoCalcMissingType_ManualWorkOnMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动调整上班漏打";
								 case "zh-HK":
									 return "手動調整上班漏打";
								  case "en-US":
									 return "Manual WorkOn Missing";
 								 
 								 default:									 
									 return "Manual WorkOn Missing";
							} 
 					}
				}


				 ///<summary>無漏打</summary>
				public static string AutoCalcMissingType_NoMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无漏打";
								 case "zh-HK":
									 return "無漏打";
								  case "en-US":
									 return "No Missing";
 								 
 								 default:									 
									 return "No Missing";
							} 
 					}
				}


				 ///<summary>凍結狀態中</summary>
				public static string BanApprove_ReturnIsBlockStatus
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "冻结状态中";
								 case "zh-HK":
									 return "凍結狀態中";
								  case "en-US":
									 return "Is Block State";
 								 
 								 default:									 
									 return "Is Block State";
							} 
 					}
				}


				 ///<summary>解除凍結狀態</summary>
				public static string BanApprove_ReturnIsUnBlockStatus
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "解除冻结状态";
								 case "zh-HK":
									 return "解除凍結狀態";
								  case "en-US":
									 return "It is Active State";
 								 
 								 default:									 
									 return "It is Active State";
							} 
 					}
				}


				 ///<summary>自动</summary>
				public static string CalcMissingMode_AUTO
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自动";
								 case "zh-HK":
									 return "自动";
								  case "en-US":
									 return "AUTO";
 								 
 								 default:									 
									 return "AUTO";
							} 
 					}
				}


				 ///<summary>手动</summary>
				public static string CalcMissingMode_MANUAL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动";
								 case "zh-HK":
									 return "手动";
								  case "en-US":
									 return "MANUAL";
 								 
 								 default:									 
									 return "MANUAL";
							} 
 					}
				}


				 ///<summary>無計算</summary>
				public static string CalcMissingMode_NOCALC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无计算";
								 case "zh-HK":
									 return "無計算";
								  case "en-US":
									 return "NO CALC";
 								 
 								 default:									 
									 return "NO CALC";
							} 
 					}
				}


				 ///<summary>RTD</summary>
				public static string CalcMissingMode_RESERVED_TO_DO
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "RTD";
								 case "zh-HK":
									 return "RTD";
								  case "en-US":
									 return "RTD";
 								 
 								 default:									 
									 return "RTD";
							} 
 					}
				}


				 ///<summary>自定義</summary>
				public static string CalcPeriodType_DEFINITION
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自定义";
								 case "zh-HK":
									 return "自定義";
								  case "en-US":
									 return "Definition";
 								 
 								 default:									 
									 return "Definition";
							} 
 					}
				}


				 ///<summary>考勤排班日歷視圖</summary>
				public static string CalendarSchedule_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤排班日历视图";
								 case "zh-HK":
									 return "考勤排班日歷視圖";
								  case "en-US":
									 return "Employee calendar schedule";
 								 
 								 default:									 
									 return "Employee calendar schedule";
							} 
 					}
				}


				 ///<summary>卡號已經建檔</summary>
				public static string CardDocBuild_CardNoHasBuilt
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号已经建档";
								 case "zh-HK":
									 return "卡號已經建檔";
								  case "en-US":
									 return "The Card No Document Has Built.";
 								 
 								 default:									 
									 return "The Card No Document Has Built.";
							} 
 					}
				}


				 ///<summary>白卡號的物理ID已經存在記錄。</summary>
				public static string CardDocBuild_PhysicalIdIsHasExist
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "白卡号的物理ID已经存在记录。";
								 case "zh-HK":
									 return "白卡號的物理ID已經存在記錄。";
								  case "en-US":
									 return "The Physical ID OF The Blank Card Has Existed Record.";
 								 
 								 default:									 
									 return "The Physical ID OF The Blank Card Has Existed Record.";
							} 
 					}
				}


				 ///<summary>卡號建檔</summary>
				public static string CardDocBuild_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号建档";
								 case "zh-HK":
									 return "卡號建檔";
								  case "en-US":
									 return "Card No Document Build";
 								 
 								 default:									 
									 return "Card No Document Build";
							} 
 					}
				}


				 ///<summary>咭號</summary>
				public static string CardManage_CardNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号";
								 case "zh-HK":
									 return "咭號";
								  case "en-US":
									 return "CardNo";
 								 
 								 default:									 
									 return "CardNo";
							} 
 					}
				}


				 ///<summary>NFC咭號建檔</summary>
				public static string CardManage_CardNoDocBuild
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "NFC咭号建档";
								 case "zh-HK":
									 return "NFC咭號建檔";
								  case "en-US":
									 return "Card No. Build";
 								 
 								 default:									 
									 return "Card No. Build";
							} 
 					}
				}


				 ///<summary>當前白卡已經被占用。</summary>
				public static string CardManage_CurrentPhysicalIdIsOccupied
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当前白卡已经被占用。";
								 case "zh-HK":
									 return "當前白卡已經被占用。";
								  case "en-US":
									 return "This Card Is Occupied";
 								 
 								 default:									 
									 return "This Card Is Occupied";
							} 
 					}
				}


				 ///<summary>ID</summary>
				public static string CardManage_Id
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ID";
								 case "zh-HK":
									 return "ID";
								  case "en-US":
									 return "ID";
 								 
 								 default:									 
									 return "ID";
							} 
 					}
				}


				 ///<summary>虛擬咭號</summary>
				public static string CardManage_MapToUserDeviceSerialNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "虚拟卡号";
								 case "zh-HK":
									 return "虛擬咭號";
								  case "en-US":
									 return "Virtual Card No";
 								 
 								 default:									 
									 return "Virtual Card No";
							} 
 					}
				}


				 ///<summary>卡號持有者</summary>
				public static string CardManage_OccupiedByEmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号持有者";
								 case "zh-HK":
									 return "卡號持有者";
								  case "en-US":
									 return "Card Holder";
 								 
 								 default:									 
									 return "Card Holder";
							} 
 					}
				}


				 ///<summary>物理ID</summary>
				public static string CardManage_PhysicalId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "物理ID";
								 case "zh-HK":
									 return "物理ID";
								  case "en-US":
									 return "Physical ID";
 								 
 								 default:									 
									 return "Physical ID";
							} 
 					}
				}


				 ///<summary>卡物理ID空白</summary>
				public static string CardManage_PhysicalIdIsNull
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡物理ID空白";
								 case "zh-HK":
									 return "卡物理ID空白";
								  case "en-US":
									 return "PhysicalId Is Null";
 								 
 								 default:									 
									 return "PhysicalId Is Null";
							} 
 					}
				}


				 ///<summary>狀態</summary>
				public static string CardManage_Status
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "状态";
								 case "zh-HK":
									 return "狀態";
								  case "en-US":
									 return "Status";
 								 
 								 default:									 
									 return "Status";
							} 
 					}
				}


				 ///<summary>卡號沒有對應的考勤人員</summary>
				public static string CardManage_TheCardNoCorrespondingPerson
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号没有对应的考勤人员";
								 case "zh-HK":
									 return "卡號沒有對應的考勤人員";
								  case "en-US":
									 return "The Card number has no corresponding person!";
 								 
 								 default:									 
									 return "The Card number has no corresponding person!";
							} 
 					}
				}


				 ///<summary>卡號沒有建檔，規則：先對白卡建立檔案生成卡號。</summary>
				public static string CardManage_TheCardNumberNotBuildDocument
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号没有建档，规则：先对白卡建立档案生成卡号。";
								 case "zh-HK":
									 return "卡號沒有建檔，規則：先對白卡建立檔案生成卡號。";
								  case "en-US":
									 return "No Corresponding Card Number Record";
 								 
 								 default:									 
									 return "No Corresponding Card Number Record";
							} 
 					}
				}


				 ///<summary>建檔卡號列表</summary>
				public static string CardManageList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "建档卡号列表";
								 case "zh-HK":
									 return "建檔卡號列表";
								  case "en-US":
									 return "Card No Manage";
 								 
 								 default:									 
									 return "Card No Manage";
							} 
 					}
				}


				 ///<summary>為卡號建立檔案</summary>
				public static string CardNoMap_BuildTheCardNoDoc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "为卡号建立档案";
								 case "zh-HK":
									 return "為卡號建立檔案";
								  case "en-US":
									 return "Build the card No. doc";
 								 
 								 default:									 
									 return "Build the card No. doc";
							} 
 					}
				}


				 ///<summary>建立考勤卡號檔案</summary>
				public static string CardNoMap_BuildTheCardNoDocument
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "建立考勤卡号档案";
								 case "zh-HK":
									 return "建立考勤卡號檔案";
								  case "en-US":
									 return "Build the card No. doc";
 								 
 								 default:									 
									 return "Build the card No. doc";
							} 
 					}
				}


				 ///<summary>為卡號建立檔案</summary>
				public static string CardNoMap_GotoBuildTheCardNoDocument
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "为卡号建立档案";
								 case "zh-HK":
									 return "為卡號建立檔案";
								  case "en-US":
									 return "Go to build the card no document First";
 								 
 								 default:									 
									 return "Go to build the card no document First";
							} 
 					}
				}


				 ///<summary>下載手機APP,安裝后點擊菜單導航至獲取手機序列號頁面就可以獲取</summary>
				public static string CardNoMap_HowToGetSerialNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下载手机APP,安装后点击菜单导航至获取手机序列号页面就可以获取";
								 case "zh-HK":
									 return "下載手機APP,安裝后點擊菜單導航至獲取手機序列號頁面就可以獲取";
								  case "en-US":
									 return "Download the mobile APP, click the menu to navigate to the page of obtaining the serial number of the mobile phone after installation, you can get it";
 								 
 								 default:									 
									 return "Download the mobile APP, click the menu to navigate to the page of obtaining the serial number of the mobile phone after installation, you can get it";
							} 
 					}
				}


				 ///<summary>沒有對應卡號或考勤Id</summary>
				public static string CardNoMap_RequiredOfCardNoOrOccupiedByEmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有对应卡号或考勤Id";
								 case "zh-HK":
									 return "沒有對應卡號或考勤Id";
								  case "en-US":
									 return "CardNo or EmployeeId is Required";
 								 
 								 default:									 
									 return "CardNo or EmployeeId is Required";
							} 
 					}
				}


				 ///<summary>需要設備序列號</summary>
				public static string CardNoMap_RequiredOfDeviceSerialNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "需要设备序列号";
								 case "zh-HK":
									 return "需要設備序列號";
								  case "en-US":
									 return "Required Device SerialNo";
 								 
 								 default:									 
									 return "Required Device SerialNo";
							} 
 					}
				}


				 ///<summary>沒有對應的白卡物理ID記錄關聯，可能沒有建檔。</summary>
				public static string CardNoMap_ThisPhysicalIdIsNotExist
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有对应的白卡物理ID记录和卡号关联，可能没有建档。";
								 case "zh-HK":
									 return "沒有對應的白卡物理ID記錄關聯，可能沒有建檔。";
								  case "en-US":
									 return "This Physical ID Is not Exist，Maybe not to build the decument.";
 								 
 								 default:									 
									 return "This Physical ID Is not Exist，Maybe not to build the decument.";
							} 
 					}
				}


				 ///<summary>取消關聯</summary>
				public static string CarManage_CamcelRelationship
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "取消关联";
								 case "zh-HK":
									 return "取消關聯";
								  case "en-US":
									 return "Camcel Relatetionship";
 								 
 								 default:									 
									 return "Camcel Relatetionship";
							} 
 					}
				}


				 ///<summary>規則：NFC白卡先進行建檔，把NFC卡的內置物理ID關聯到自定義的、可讀性的、具有自定義規則的卡號。使拍卡事件POST回來的物理ID能查詢到自定義的卡號。這個規則流程的目的是為了建立自己的卡號編號規則，杜絕非法NFC卡攻擊。例如：物理ID:PyX6d4f3dD 自定義卡號：A00001</summary>
				public static string CarManage_CardDocRuleDesc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "规则：NFC白卡先进行建档，把NFC卡的内置物理ID关联到自定义的、可读性的、具有自定义规则的卡号。使拍卡事件POST回来的物理ID能查询到自定义的卡号。这个规则流程的目的是为了建立自己的卡号编号规则，杜绝非法NFC卡攻击。例如：物理ID:PyX6d4f3dD 自定义卡号：A00001";
								 case "zh-HK":
									 return "規則：NFC白卡先進行建檔，把NFC卡的內置物理ID關聯到自定義的、可讀性的、具有自定義規則的卡號。使拍卡事件POST回來的物理ID能查詢到自定義的卡號。這個規則流程的目的是為了建立自己的卡號編號規則，杜絕非法NFC卡攻擊。例如：物理ID:PyX6d4f3dD 自定義卡號：A00001";
								  case "en-US":
									 return "Rules: The NFC white card is built relatetionship first, and the built-in physical ID of the NFC card is associated with a custom readable card number with custom manage rules. The physical ID returned from the POST of the card event can be queried to the relate custom card number. The purpose of this rule is to establish your own card numbering rule,and put an end to illegal NFC card attacks. For example: Physical ID: PyX6d4f3dD Custom card number: A00001";
 								 
 								 default:									 
									 return "Rules: The NFC white card is built relatetionship first, and the built-in physical ID of the NFC card is associated with a custom readable card number with custom manage rules. The physical ID returned from the POST of the card event can be queried to the relate custom card number. The purpose of this rule is to establish your own card numbering rule,and put an end to illegal NFC card attacks. For example: Physical ID: PyX6d4f3dD Custom card number: A00001";
							} 
 					}
				}


				 ///<summary>卡編號</summary>
				public static string CarManage_CardNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡编号";
								 case "zh-HK":
									 return "卡編號";
								  case "en-US":
									 return "Card Number";
 								 
 								 default:									 
									 return "Card Number";
							} 
 					}
				}


				 ///<summary>卡號關聯</summary>
				public static string CarManage_CardRelateToEmployeeTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号关联";
								 case "zh-HK":
									 return "卡號關聯";
								  case "en-US":
									 return "Relate to Card Number";
 								 
 								 default:									 
									 return "Relate to Card Number";
							} 
 					}
				}


				 ///<summary>虛擬卡號</summary>
				public static string CarManage_MapToUserDeviceSerialNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "虚拟卡号";
								 case "zh-HK":
									 return "虛擬卡號";
								  case "en-US":
									 return "Virtual Card No";
 								 
 								 default:									 
									 return "Virtual Card No";
							} 
 					}
				}


				 ///<summary>虛擬卡號關聯</summary>
				public static string CarManage_MapToUserDeviceSerialNoRelate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "虚拟卡号关联";
								 case "zh-HK":
									 return "虛擬卡號關聯";
								  case "en-US":
									 return "Virtual Card No Relationship";
 								 
 								 default:									 
									 return "Virtual Card No Relationship";
							} 
 					}
				}


				 ///<summary>Card 物理ID</summary>
				public static string CarManage_PhysicalId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "白卡物理ID";
								 case "zh-HK":
									 return "Card 物理ID";
								  case "en-US":
									 return "PhysicalId";
 								 
 								 default:									 
									 return "PhysicalId";
							} 
 					}
				}


				 ///<summary>虛擬卡號規則：把設備序列號作為卡號。例如手機安裝app，產生的設備序列號作為卡號。</summary>
				public static string CarManage_VirtualCardNoDocRuleDesc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "虚拟卡号规则：把设备序列号作为卡号。例如手机安装app，产生的设备序列号作为卡号。";
								 case "zh-HK":
									 return "虛擬卡號規則：把設備序列號作為卡號。例如手機安裝app，產生的設備序列號作為卡號。";
								  case "en-US":
									 return "Virtual card number rule: Use the device serial number as the card number. For example, when an app is installed on a mobile phone, the generated device serial number is used as the card number.";
 								 
 								 default:									 
									 return "Virtual card number rule: Use the device serial number as the card number. For example, when an app is installed on a mobile phone, the generated device serial number is used as the card number.";
							} 
 					}
				}


				 ///<summary>公司地址</summary>
				public static string Contractor_CompanyAddress
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司地址";
								 case "zh-HK":
									 return "公司地址";
								  case "en-US":
									 return "Address";
 								 
 								 default:									 
									 return "Address";
							} 
 					}
				}


				 ///<summary>公司傳真</summary>
				public static string Contractor_CompanyFax
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司传真";
								 case "zh-HK":
									 return "公司傳真";
								  case "en-US":
									 return "Company Fax ";
 								 
 								 default:									 
									 return "Company Fax ";
							} 
 					}
				}


				 ///<summary>第三方服務公司</summary>
				public static string Contractor_CompanyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方服务公司";
								 case "zh-HK":
									 return "第三方服務公司";
								  case "en-US":
									 return "The 3rd Company";
 								 
 								 default:									 
									 return "The 3rd Company";
							} 
 					}
				}


				 ///<summary>公司Logo</summary>
				public static string Contractor_CompanyNameLogo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司Logo";
								 case "zh-HK":
									 return "公司Logo";
								  case "en-US":
									 return "Logo";
 								 
 								 default:									 
									 return "Logo";
							} 
 					}
				}


				 ///<summary>公司電話</summary>
				public static string Contractor_CompanyTel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司电话";
								 case "zh-HK":
									 return "公司電話";
								  case "en-US":
									 return "Company Tel ";
 								 
 								 default:									 
									 return "Company Tel ";
							} 
 					}
				}


				 ///<summary>公司聯系人</summary>
				public static string Contractor_ContactName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司联系人";
								 case "zh-HK":
									 return "公司聯系人";
								  case "en-US":
									 return "Contact";
 								 
 								 default:									 
									 return "Contact";
							} 
 					}
				}


				 ///<summary>聯系人手機</summary>
				public static string Contractor_ContactPhone
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "联系人手机";
								 case "zh-HK":
									 return "聯系人手機";
								  case "en-US":
									 return "Contact Phone ";
 								 
 								 default:									 
									 return "Contact Phone ";
							} 
 					}
				}


				 ///<summary>二判新增</summary>
				public static string Contractor_ContractorAddNew_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "二判新增";
								 case "zh-HK":
									 return "二判新增";
								  case "en-US":
									 return "Contractor Add";
 								 
 								 default:									 
									 return "Contractor Add";
							} 
 					}
				}


				 ///<summary>ID</summary>
				public static string Contractor_ContractorId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ID";
								 case "zh-HK":
									 return "ID";
								  case "en-US":
									 return "ID";
 								 
 								 default:									 
									 return "ID";
							} 
 					}
				}


				 ///<summary>Contractor</summary>
				public static string Contractor_ContractorName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Contractor";
								 case "zh-HK":
									 return "Contractor";
								  case "en-US":
									 return "Contractor Name";
 								 
 								 default:									 
									 return "Contractor Name";
							} 
 					}
				}


				 ///<summary>合約編號</summary>
				public static string Contractor_ContractorNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "合约编号";
								 case "zh-HK":
									 return "合約編號";
								  case "en-US":
									 return "ContractorNo";
 								 
 								 default:									 
									 return "ContractorNo";
							} 
 					}
				}


				 ///<summary>行業Id</summary>
				public static string Contractor_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业Id";
								 case "zh-HK":
									 return "行業Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>所屬行業</summary>
				public static string Contractor_IndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "所属行业";
								 case "zh-HK":
									 return "所屬行業";
								  case "en-US":
									 return "Industry";
 								 
 								 default:									 
									 return "Industry";
							} 
 					}
				}


				 ///<summary>ContractorId</summary>
				public static string Contractor_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ContractorId";
								 case "zh-HK":
									 return "ContractorId";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>輸入二判名稱</summary>
				public static string Contractor_NeedContractorName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "输入二判名称";
								 case "zh-HK":
									 return "輸入二判名稱";
								  case "en-US":
									 return "Need Contractor Name";
 								 
 								 default:									 
									 return "Need Contractor Name";
							} 
 					}
				}


				 ///<summary>操作日期</summary>
				public static string Contractor_OperatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作日期";
								 case "zh-HK":
									 return "操作日期";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>操作用戶</summary>
				public static string Contractor_OperatedUserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作用户";
								 case "zh-HK":
									 return "操作用戶";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>合約服務期</summary>
				public static string Contractor_ServiceDateRange
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "合约服务期";
								 case "zh-HK":
									 return "合約服務期";
								  case "en-US":
									 return "Service Date Range";
 								 
 								 default:									 
									 return "Service Date Range";
							} 
 					}
				}


				 ///<summary>服務結束</summary>
				public static string Contractor_ServiceEndDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "服务结束";
								 case "zh-HK":
									 return "服務結束";
								  case "en-US":
									 return "ServiceEnd";
 								 
 								 default:									 
									 return "ServiceEnd";
							} 
 					}
				}


				 ///<summary>服務啟動</summary>
				public static string Contractor_ServiceStartDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "服务启动";
								 case "zh-HK":
									 return "服務啟動";
								  case "en-US":
									 return "ServiceStart";
 								 
 								 default:									 
									 return "ServiceStart";
							} 
 					}
				}


				 ///<summary>日期范圍格式不正確</summary>
				public static string ContractorAddNew_SetServiceDateRangeErr
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日期范围格式不正确";
								 case "zh-HK":
									 return "日期范圍格式不正確";
								  case "en-US":
									 return "Service Date Range Error";
 								 
 								 default:									 
									 return "Service Date Range Error";
							} 
 					}
				}


				 ///<summary>好的，再考慮一下吧！</summary>
				public static string ContractorList_ComfirmNoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "好的，再考虑一下吧！";
								 case "zh-HK":
									 return "好的，再考慮一下吧！";
								  case "en-US":
									 return "OK! Let‘s think about it!";
 								 
 								 default:									 
									 return "OK! Let‘s think about it!";
							} 
 					}
				}


				 ///<summary>確定刪除當前二判嗎？</summary>
				public static string ContractorList_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确定删除当前二判吗？";
								 case "zh-HK":
									 return "確定刪除當前二判嗎？";
								  case "en-US":
									 return "Comfirm to delte?";
 								 
 								 default:									 
									 return "Comfirm to delte?";
							} 
 					}
				}


				 ///<summary>二判編輯</summary>
				public static string ContractorList_EditContractorDetails_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "二判编辑";
								 case "zh-HK":
									 return "二判編輯";
								  case "en-US":
									 return "Edit Contractor";
 								 
 								 default:									 
									 return "Edit Contractor";
							} 
 					}
				}


				 ///<summary>二判列表</summary>
				public static string ContractorList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "二判列表";
								 case "zh-HK":
									 return "二判列表";
								  case "en-US":
									 return "ContractorList";
 								 
 								 default:									 
									 return "ContractorList";
							} 
 					}
				}


				 ///<summary>仪表板 Dashbord</summary>
				public static string Dashbord_Index_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "仪表板 Dashbord";
								 case "zh-HK":
									 return "仪表板 Dashbord";
								  case "en-US":
									 return "Dashbord";
 								 
 								 default:									 
									 return "Dashbord";
							} 
 					}
				}


				 ///<summary>日考勤統計報表</summary>
				public static string DayStatistics_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日考勤统计报表";
								 case "zh-HK":
									 return "日考勤統計報表";
								  case "en-US":
									 return "Statistics by day";
 								 
 								 default:									 
									 return "Statistics by day";
							} 
 					}
				}


				 ///<summary>請先在雇員列表中清除所屬的合约二判</summary>
				public static string DelContractor_EmployeeExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先在雇员列表中清除所属的合约二判";
								 case "zh-HK":
									 return "請先在雇員列表中清除所屬的合约二判";
								  case "en-US":
									 return "Please clear these contractors in Employee list at first!";
 								 
 								 default:									 
									 return "Please clear these contractors in Employee list at first!";
							} 
 					}
				}


				 ///<summary>請先清除所屬的部門</summary>
				public static string DeleteDepartment_EmployeeExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先清除所属的部门";
								 case "zh-HK":
									 return "請先清除所屬的部門";
								  case "en-US":
									 return "Please clear the department in the employee list";
 								 
 								 default:									 
									 return "Please clear the department in the employee list";
							} 
 					}
				}


				 ///<summary>請先在雇員列表中清除所屬的職位</summary>
				public static string DelPosition_EmployeeExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先在雇员列表中清除所属的职位";
								 case "zh-HK":
									 return "請先在雇員列表中清除所屬的職位";
								  case "en-US":
									 return "Please clear these positions in Employee list at first!";
 								 
 								 default:									 
									 return "Please clear these positions in Employee list at first!";
							} 
 					}
				}


				 ///<summary>部門名稱</summary>
				public static string Department_CompanyAbbreviation
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部門名稱";
								 case "zh-HK":
									 return "部門名稱";
								  case "en-US":
									 return "部門名稱";
 								 
 								 default:									 
									 return "部門名稱";
							} 
 					}
				}


				 ///<summary>所屬公司</summary>
				public static string Department_CompanyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "所屬公司";
								 case "zh-HK":
									 return "所屬公司";
								  case "en-US":
									 return "所屬公司";
 								 
 								 default:									 
									 return "所屬公司";
							} 
 					}
				}


				 ///<summary>部門簡稱</summary>
				public static string Department_DepartmentAbbrName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部門簡稱";
								 case "zh-HK":
									 return "部門簡稱";
								  case "en-US":
									 return "部門簡稱";
 								 
 								 default:									 
									 return "部門簡稱";
							} 
 					}
				}


				 ///<summary>新增部門</summary>
				public static string Department_DepartmentAddNew_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新增部门";
								 case "zh-HK":
									 return "新增部門";
								  case "en-US":
									 return "Department Add New";
 								 
 								 default:									 
									 return "Department Add New";
							} 
 					}
				}


				 ///<summary>所有部門</summary>
				public static string Department_DEPARTMENTALL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "所有部门";
								 case "zh-HK":
									 return "所有部門";
								  case "en-US":
									 return "ALL OF DEPARTMENTS";
 								 
 								 default:									 
									 return "ALL OF DEPARTMENTS";
							} 
 					}
				}


				 ///<summary>DepartmentId</summary>
				public static string Department_DepartmentId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "DepartmentId";
								 case "zh-HK":
									 return "DepartmentId";
								  case "en-US":
									 return "DepartmentId";
 								 
 								 default:									 
									 return "DepartmentId";
							} 
 					}
				}


				 ///<summary>部門名稱</summary>
				public static string Department_DepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门名称";
								 case "zh-HK":
									 return "部門名稱";
								  case "en-US":
									 return "Department Name";
 								 
 								 default:									 
									 return "Department Name";
							} 
 					}
				}


				 ///<summary>部門資料編輯</summary>
				public static string Department_EditDepartmentDetails_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门资料编辑";
								 case "zh-HK":
									 return "部門資料編輯";
								  case "en-US":
									 return "Department Details Edit";
 								 
 								 default:									 
									 return "Department Details Edit";
							} 
 					}
				}


				 ///<summary>部門英文名稱</summary>
				public static string Department_EnDepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门英文名称";
								 case "zh-HK":
									 return "部門英文名稱";
								  case "en-US":
									 return "Department English Name";
 								 
 								 default:									 
									 return "Department English Name";
							} 
 					}
				}


				 ///<summary>MainComId</summary>
				public static string Department_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "MainComId";
								 case "zh-HK":
									 return "MainComId";
								  case "en-US":
									 return "MainComId";
 								 
 								 default:									 
									 return "MainComId";
							} 
 					}
				}


				 ///<summary>部門記錄不存在！</summary>
				public static string Department_NotExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门记录不存在！";
								 case "zh-HK":
									 return "部門記錄不存在！";
								  case "en-US":
									 return "This department record is not exist!";
 								 
 								 default:									 
									 return "This department record is not exist!";
							} 
 					}
				}


				 ///<summary>存在相同的部門名稱</summary>
				public static string DepartmentAddNew_ExistTheSameDepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在相同的部门名称";
								 case "zh-HK":
									 return "存在相同的部門名稱";
								  case "en-US":
									 return "Exist the same department name";
 								 
 								 default:									 
									 return "Exist the same department name";
							} 
 					}
				}


				 ///<summary>不存在的公司ID(MainComId)</summary>
				public static string DepartmentAddNew_NotExistMainCom
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "不存在的公司ID(MainComId)";
								 case "zh-HK":
									 return "不存在的公司ID(MainComId)";
								  case "en-US":
									 return "Not exist the MainComId";
 								 
 								 default:									 
									 return "Not exist the MainComId";
							} 
 					}
				}


				 ///<summary>需要部門名稱</summary>
				public static string DepartmentDetails_NeedDepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "需要部门名称";
								 case "zh-HK":
									 return "需要部門名稱";
								  case "en-US":
									 return "Need the department name";
 								 
 								 default:									 
									 return "Need the department name";
							} 
 					}
				}


				 ///<summary>好的，再考慮一下吧！</summary>
				public static string DepartmentList_ComfirmNoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "好的，再考虑一下吧！";
								 case "zh-HK":
									 return "好的，再考慮一下吧！";
								  case "en-US":
									 return "OK! Let‘s think about it!";
 								 
 								 default:									 
									 return "OK! Let‘s think about it!";
							} 
 					}
				}


				 ///<summary>確認刪除當前部門嗎？</summary>
				public static string DepartmentList_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认删除当前部门吗？";
								 case "zh-HK":
									 return "確認刪除當前部門嗎？";
								  case "en-US":
									 return "Comfirm delete this department?";
 								 
 								 default:									 
									 return "Comfirm delete this department?";
							} 
 					}
				}


				 ///<summary>已產生記錄的部門被刪除可能影響數據完整性哦！</summary>
				public static string DepartmentList_ComfirmTips2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已产生记录的部门被删除可能影响数据完整性哦！";
								 case "zh-HK":
									 return "已產生記錄的部門被刪除可能影響數據完整性哦！";
								  case "en-US":
									 return "Deleted department record,It may cause the data integrity!";
 								 
 								 default:									 
									 return "Deleted department record,It may cause the data integrity!";
							} 
 					}
				}


				 ///<summary>部門管理列表</summary>
				public static string DepartmentList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门管理列表";
								 case "zh-HK":
									 return "部門管理列表";
								  case "en-US":
									 return "Department List";
 								 
 								 default:									 
									 return "Department List";
							} 
 					}
				}


				 ///<summary>必須填入部門名稱</summary>
				public static string DepartmentView_DepartmentName_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "必须填入部门名称";
								 case "zh-HK":
									 return "必須填入部門名稱";
								  case "en-US":
									 return "The departmentName is required";
 								 
 								 default:									 
									 return "The departmentName is required";
							} 
 					}
				}


				 ///<summary>已經確定設備正常運行后，登記以啟動設備。</summary>
				public static string DevCreate_StatusMessageTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已?确定??正常?行后，登?以????。";
								 case "zh-HK":
									 return "已經確定設備正常運行后，登記以啟動設備。";
								  case "en-US":
									 return "After it has been determined that the device is operating normally, register to start the device.";
 								 
 								 default:									 
									 return "After it has been determined that the device is operating normally, register to start the device.";
							} 
 					}
				}


				 ///<summary>登記以啟動設備</summary>
				public static string DevCreate_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登记以启动设备";
								 case "zh-HK":
									 return "登記以啟動設備";
								  case "en-US":
									 return "Register to activate the device";
 								 
 								 default:									 
									 return "Register to activate the device";
							} 
 					}
				}


				 ///<summary>設備名稱</summary>
				public static string Device_DeviceName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "??名?";
								 case "zh-HK":
									 return "設備名稱";
								  case "en-US":
									 return "Device Name";
 								 
 								 default:									 
									 return "Device Name";
							} 
 					}
				}


				 ///<summary>設備序列號</summary>
				public static string Device_DeviceSerialNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "??序列?";
								 case "zh-HK":
									 return "設備序列號";
								  case "en-US":
									 return "Device SerialNo";
 								 
 								 default:									 
									 return "Device SerialNo";
							} 
 					}
				}


				 ///<summary>請先注冊公司或組織</summary>
				public static string DeviceCreate_MainComRegisterFirst
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先注册公司或组织";
								 case "zh-HK":
									 return "請先注冊公司或組織";
								  case "en-US":
									 return "Co./Org Registeation First";
 								 
 								 default:									 
									 return "Co./Org Registeation First";
							} 
 					}
				}


				 ///<summary>入口類型設備</summary>
				public static string DeviceEntryMode_IN
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "入口类型设备";
								 case "zh-HK":
									 return "入口類型設備";
								  case "en-US":
									 return "IN";
 								 
 								 default:									 
									 return "IN";
							} 
 					}
				}


				 ///<summary>InOut</summary>
				public static string DeviceEntryMode_INOUT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "InOut";
								 case "zh-HK":
									 return "InOut";
								  case "en-US":
									 return "InOut";
 								 
 								 default:									 
									 return "InOut";
							} 
 					}
				}


				 ///<summary>出口類型設備</summary>
				public static string DeviceEntryMode_OUT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "出口类型设备";
								 case "zh-HK":
									 return "出口類型設備";
								  case "en-US":
									 return "OUT";
 								 
 								 default:									 
									 return "OUT";
							} 
 					}
				}


				 ///<summary>未定義</summary>
				public static string DeviceEntryMode_UNDEFINED
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "未定义";
								 case "zh-HK":
									 return "未定義";
								  case "en-US":
									 return "UNDEFINED";
 								 
 								 default:									 
									 return "UNDEFINED";
							} 
 					}
				}


				 ///<summary>要求填入DeviceId</summary>
				public static string DeviceUser_DeviceId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "要求填入DeviceId";
								 case "zh-HK":
									 return "要求填入DeviceId";
								  case "en-US":
									 return "EmployeeId is Required";
 								 
 								 default:									 
									 return "EmployeeId is Required";
							} 
 					}
				}


				 ///<summary>正面大頭照</summary>
				public static string DeviceUser_UserIconPositive
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "正面大头照";
								 case "zh-HK":
									 return "正面大頭照";
								  case "en-US":
									 return "User Positive Avatar";
 								 
 								 default:									 
									 return "User Positive Avatar";
							} 
 					}
				}


				 ///<summary>偏正面大頭照</summary>
				public static string DeviceUser_UserIconSide
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "偏正面大头照";
								 case "zh-HK":
									 return "偏正面大頭照";
								  case "en-US":
									 return "User Side Avatar";
 								 
 								 default:									 
									 return "User Side Avatar";
							} 
 					}
				}


				 ///<summary>偏下大頭照</summary>
				public static string DeviceUser_UserIconTopView
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "偏下大头照";
								 case "zh-HK":
									 return "偏下大頭照";
								  case "en-US":
									 return "User Top Avatar";
 								 
 								 default:									 
									 return "User Top Avatar";
							} 
 					}
				}


				 ///<summary>多語言字典編輯</summary>
				public static string EditLangDetail_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "多语言字典编辑";
								 case "zh-HK":
									 return "多語言字典編輯";
								  case "en-US":
									 return "Edit Language Details";
 								 
 								 default:									 
									 return "Edit Language Details";
							} 
 					}
				}


				 ///<summary>通行卡ID</summary>
				public static string Employee_AccessCardId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "通行卡ID";
								 case "zh-HK":
									 return "通行卡ID";
								  case "en-US":
									 return "AccessCardId";
 								 
 								 default:									 
									 return "AccessCardId";
							} 
 					}
				}


				 ///<summary>第一、考勤Card Number和虛擬考勤Card Number是共用一個狀態，改變{使用中}，{停用中}都會同時改變這兩個Card Number的狀態。第二、兩種類型都可以同時使用。第三、虛擬卡號是使持有者手機NFC感應區放置NFC卡上。</summary>
				public static string Employee_AccessCardIdRuleDesc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第一、考勤Card Number和虚拟考勤Card Number是共用一个状态，改变{使用中}，{停用中}都会同时改变这两个Card Number的状态。第二、两种类型都可以同时使用。第三、虚拟卡号是使持有者手机NFC感应区放置NFC卡上。";
								 case "zh-HK":
									 return "第一、考勤Card Number和虛擬考勤Card Number是共用一個狀態，改變{使用中}，{停用中}都會同時改變這兩個Card Number的狀態。第二、兩種類型都可以同時使用。第三、虛擬卡號是使持有者手機NFC感應區放置NFC卡上。";
								  case "en-US":
									 return "First. Attendance Card Number and Virtual Attendance Card Number share the same status. Changing {In Use},{Disabled} will change the status of these two Card Numbers at the same time. Second, both types can be used at the same time. Third, the virtual card number is to place the NFC card on the NFC induction area of the holders mobile phone.";
 								 
 								 default:									 
									 return "First. Attendance Card Number and Virtual Attendance Card Number share the same status. Changing {In Use},{Disabled} will change the status of these two Card Numbers at the same time. Second, both types can be used at the same time. Third, the virtual card number is to place the NFC card on the NFC induction area of the holders mobile phone.";
							} 
 					}
				}


				 ///<summary>按部門Assign到設備</summary>
				public static string Employee_ApplyDepartmentToDevice
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "按部门Assign到设备";
								 case "zh-HK":
									 return "按部門Assign到設備";
								  case "en-US":
									 return "Assign to device by department";
 								 
 								 default:									 
									 return "Assign to device by department";
							} 
 					}
				}


				 ///<summary>Assign到设备</summary>
				public static string Employee_ApplyToDevice
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Assign到设备";
								 case "zh-HK":
									 return "Assign到设备";
								  case "en-US":
									 return "Assign to Device";
 								 
 								 default:									 
									 return "Assign to Device";
							} 
 					}
				}


				 ///<summary>離職審核</summary>
				public static string Employee_ArchiveApprovePanel_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "离职审核";
								 case "zh-HK":
									 return "離職審核";
								  case "en-US":
									 return "Archive Approve";
 								 
 								 default:									 
									 return "Archive Approve";
							} 
 					}
				}


				 ///<summary>請輸入ID</summary>
				public static string Employee_AssociateToUser_InputIdTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入ID";
								 case "zh-HK":
									 return "請輸入ID";
								  case "en-US":
									 return "Please input ID";
 								 
 								 default:									 
									 return "Please input ID";
							} 
 					}
				}


				 ///<summary>請輸入系統用戶ID</summary>
				public static string Employee_AssociateToUser_InputUserIdTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入系统用户ID";
								 case "zh-HK":
									 return "請輸入系統用戶ID";
								  case "en-US":
									 return "Please input System User ID";
 								 
 								 default:									 
									 return "Please input System User ID";
							} 
 					}
				}


				 ///<summary>與系統用戶關聯</summary>
				public static string Employee_AssociateToUserPanel_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "与系统用户关联";
								 case "zh-HK":
									 return "與系統用戶關聯";
								  case "en-US":
									 return "Associate to system user";
 								 
 								 default:									 
									 return "Associate to system user";
							} 
 					}
				}


				 ///<summary>出生日期</summary>
				public static string Employee_Birthday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "出生日期";
								 case "zh-HK":
									 return "出生日期";
								  case "en-US":
									 return "Birthday";
 								 
 								 default:									 
									 return "Birthday";
							} 
 					}
				}


				 ///<summary>請輸入ID</summary>
				public static string Employee_CancelRelateToUser_InputIdTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入ID";
								 case "zh-HK":
									 return "請輸入ID";
								  case "en-US":
									 return "Please input ID";
 								 
 								 default:									 
									 return "Please input ID";
							} 
 					}
				}


				 ///<summary>取消系統用戶關聯</summary>
				public static string Employee_CancelRelateToUser_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "取消系统用户关联";
								 case "zh-HK":
									 return "取消系統用戶關聯";
								  case "en-US":
									 return "Cancel relate to user";
 								 
 								 default:									 
									 return "Cancel relate to user";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string Employee_CnName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "中文姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Chinese Name";
 								 
 								 default:									 
									 return "Chinese Name";
							} 
 					}
				}


				 ///<summary>中文姓名</summary>
				public static string Employee_CnName2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "中文姓名";
								 case "zh-HK":
									 return "中文姓名";
								  case "en-US":
									 return "Chinese Name";
 								 
 								 default:									 
									 return "Chinese Name";
							} 
 					}
				}


				 ///<summary>所屬于第三方</summary>
				public static string Employee_ContractorId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "所属于第三方";
								 case "zh-HK":
									 return "所屬于第三方";
								  case "en-US":
									 return "ContractorId";
 								 
 								 default:									 
									 return "ContractorId";
							} 
 					}
				}


				 ///<summary>The 3Rd 服務公司名稱</summary>
				public static string Employee_ContractorName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "The 3Rd 服务公司名称";
								 case "zh-HK":
									 return "The 3Rd 服務公司名稱";
								  case "en-US":
									 return "The 3Rd 服务公司名称";
 								 
 								 default:									 
									 return "The 3Rd 服务公司名称";
							} 
 					}
				}


				 ///<summary>創建日期</summary>
				public static string Employee_CreatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "创建日期";
								 case "zh-HK":
									 return "創建日期";
								  case "en-US":
									 return "CreatedDate";
 								 
 								 default:									 
									 return "CreatedDate";
							} 
 					}
				}


				 ///<summary>部門</summary>
				public static string Employee_Deparment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门";
								 case "zh-HK":
									 return "部門";
								  case "en-US":
									 return "Deparment";
 								 
 								 default:									 
									 return "Deparment";
							} 
 					}
				}


				 ///<summary>部門</summary>
				public static string Employee_Department
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门";
								 case "zh-HK":
									 return "部門";
								  case "en-US":
									 return "Department";
 								 
 								 default:									 
									 return "Department";
							} 
 					}
				}


				 ///<summary>部門ID</summary>
				public static string Employee_DepartmentId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部門ID";
								 case "zh-HK":
									 return "部門ID";
								  case "en-US":
									 return "部門ID";
 								 
 								 default:									 
									 return "部門ID";
							} 
 					}
				}


				 ///<summary>部門必選的</summary>
				public static string Employee_DepartmentId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门必选的";
								 case "zh-HK":
									 return "部門必選的";
								  case "en-US":
									 return "Department is required";
 								 
 								 default:									 
									 return "Department is required";
							} 
 					}
				}


				 ///<summary>部門名稱</summary>
				public static string Employee_DepartmentName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部門名稱";
								 case "zh-HK":
									 return "部門名稱";
								  case "en-US":
									 return "部門名稱";
 								 
 								 default:									 
									 return "部門名稱";
							} 
 					}
				}


				 ///<summary>Email</summary>
				public static string Employee_Email
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email";
								 case "zh-HK":
									 return "Email";
								  case "en-US":
									 return "Email";
 								 
 								 default:									 
									 return "Email";
							} 
 					}
				}


				 ///<summary>ID</summary>
				public static string Employee_EmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ID";
								 case "zh-HK":
									 return "ID";
								  case "en-US":
									 return "ID";
 								 
 								 default:									 
									 return "ID";
							} 
 					}
				}


				 ///<summary>要求填入EmployeeId</summary>
				public static string Employee_EmployeeId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "要求填入EmployeeId";
								 case "zh-HK":
									 return "要求填入EmployeeId";
								  case "en-US":
									 return "EmployeeId is Required";
 								 
 								 default:									 
									 return "EmployeeId is Required";
							} 
 					}
				}


				 ///<summary>雇員姓名</summary>
				public static string Employee_EmployeeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "雇员姓名";
								 case "zh-HK":
									 return "雇員姓名";
								  case "en-US":
									 return "EmployeeName";
 								 
 								 default:									 
									 return "EmployeeName";
							} 
 					}
				}


				 ///<summary>英文名</summary>
				public static string Employee_EnglishName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "英文名";
								 case "zh-HK":
									 return "英文名";
								  case "en-US":
									 return "English Name";
 								 
 								 default:									 
									 return "English Name";
							} 
 					}
				}


				 ///<summary>入職日期</summary>
				public static string Employee_EnrollmentDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "入职日期";
								 case "zh-HK":
									 return "入職日期";
								  case "en-US":
									 return "EnrollmentDate";
 								 
 								 default:									 
									 return "EnrollmentDate";
							} 
 					}
				}


				 ///<summary>指纹</summary>
				public static string Employee_FingerPrint
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "指纹";
								 case "zh-HK":
									 return "指纹";
								  case "en-US":
									 return "FingerPrint";
 								 
 								 default:									 
									 return "FingerPrint";
							} 
 					}
				}


				 ///<summary>姓</summary>
				public static string Employee_FirstName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓";
								 case "zh-HK":
									 return "姓";
								  case "en-US":
									 return "FirstName";
 								 
 								 default:									 
									 return "FirstName";
							} 
 					}
				}


				 ///<summary>Full Name</summary>
				public static string Employee_FullName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Full Name";
								 case "zh-HK":
									 return "Full Name";
								  case "en-US":
									 return "Full Name";
 								 
 								 default:									 
									 return "Full Name";
							} 
 					}
				}


				 ///<summary>性別</summary>
				public static string Employee_Gender 
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "性别";
								 case "zh-HK":
									 return "性別";
								  case "en-US":
									 return "Gender ";
 								 
 								 default:									 
									 return "Gender ";
							} 
 					}
				}


				 ///<summary>已經存在關聯 {0} |  {1}(Sys User ID)</summary>
				public static string Employee_HasAssociationWithEmployee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已经存在关联 {0} | {1}(Sys User ID)";
								 case "zh-HK":
									 return "已經存在關聯 {0} |  {1}(Sys User ID)";
								  case "en-US":
									 return "Has associated between {0} with  {1}(Sys User ID)";
 								 
 								 default:									 
									 return "Has associated between {0} with  {1}(Sys User ID)";
							} 
 					}
				}


				 ///<summary>重复录入Employee ID (ErrorCode10009)</summary>
				public static string Employee_ID_ErrorCode10009
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "重复录入Employee ID (ErrorCode10009)";
								 case "zh-HK":
									 return "重复录入Employee ID (ErrorCode10009)";
								  case "en-US":
									 return "Employee ID Repeated (ErrorCode10009)";
 								 
 								 default:									 
									 return "Employee ID Repeated (ErrorCode10009)";
							} 
 					}
				}


				 ///<summary>證件號碼</summary>
				public static string Employee_IdNumber
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "证件号码";
								 case "zh-HK":
									 return "證件號碼";
								  case "en-US":
									 return "IdNumber";
 								 
 								 default:									 
									 return "IdNumber";
							} 
 					}
				}


				 ///<summary>是否離職</summary>
				public static string Employee_IsArchive
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "是否离职";
								 case "zh-HK":
									 return "是否離職";
								  case "en-US":
									 return "Is it Archive?";
 								 
 								 default:									 
									 return "Is it Archive?";
							} 
 					}
				}


				 ///<summary>白名單（豁免考勤）</summary>
				public static string Employee_IsBlock
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "白名单（豁免考勤）";
								 case "zh-HK":
									 return "白名單（豁免考勤）";
								  case "en-US":
									 return "White List（Attendance Exemption）";
 								 
 								 default:									 
									 return "White List（Attendance Exemption）";
							} 
 					}
				}


				 ///<summary>工 種</summary>
				public static string Employee_Job
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工 种";
								 case "zh-HK":
									 return "工 種";
								  case "en-US":
									 return "Job Type";
 								 
 								 default:									 
									 return "Job Type";
							} 
 					}
				}


				 ///<summary>工種編號</summary>
				public static string Employee_JobId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工種編號";
								 case "zh-HK":
									 return "工種編號";
								  case "en-US":
									 return "工種編號";
 								 
 								 default:									 
									 return "工種編號";
							} 
 					}
				}


				 ///<summary>工種</summary>
				public static string Employee_JobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种";
								 case "zh-HK":
									 return "工種";
								  case "en-US":
									 return "Job";
 								 
 								 default:									 
									 return "Job";
							} 
 					}
				}


				 ///<summary>LastName</summary>
				public static string Employee_LastName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "LastName";
								 case "zh-HK":
									 return "LastName";
								  case "en-US":
									 return "LastName";
 								 
 								 default:									 
									 return "LastName";
							} 
 					}
				}


				 ///<summary>離職日期</summary>
				public static string Employee_LeaveDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "离职日期";
								 case "zh-HK":
									 return "離職日期";
								  case "en-US":
									 return "LeaveDate";
 								 
 								 default:									 
									 return "LeaveDate";
							} 
 					}
				}


				 ///<summary>離職日期不合理（應在入職日期之后）</summary>
				public static string Employee_LeaveDateUnreasonable
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "离职日期不合理（应在入职日期之后）";
								 case "zh-HK":
									 return "離職日期不合理（應在入職日期之后）";
								  case "en-US":
									 return "Unreasonable departure date (should be after the start date)";
 								 
 								 default:									 
									 return "Unreasonable departure date (should be after the start date)";
							} 
 					}
				}


				 ///<summary>公司ID</summary>
				public static string Employee_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司ID";
								 case "zh-HK":
									 return "公司ID";
								  case "en-US":
									 return "MainComId";
 								 
 								 default:									 
									 return "MainComId";
							} 
 					}
				}


				 ///<summary>操作日期</summary>
				public static string Employee_OperatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作日期";
								 case "zh-HK":
									 return "操作日期";
								  case "en-US":
									 return "OperatedDate";
 								 
 								 default:									 
									 return "OperatedDate";
							} 
 					}
				}


				 ///<summary>操作用戶</summary>
				public static string Employee_OperatedUserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作用户";
								 case "zh-HK":
									 return "操作用戶";
								  case "en-US":
									 return "OperatedUserName";
 								 
 								 default:									 
									 return "OperatedUserName";
							} 
 					}
				}


				 ///<summary>ParentUserId</summary>
				public static string Employee_ParentUserId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ParentUserId";
								 case "zh-HK":
									 return "ParentUserId";
								  case "en-US":
									 return "ParentUserId";
 								 
 								 default:									 
									 return "ParentUserId";
							} 
 					}
				}


				 ///<summary>手機</summary>
				public static string Employee_PhoneNumber
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手机";
								 case "zh-HK":
									 return "手機";
								  case "en-US":
									 return "Mobile";
 								 
 								 default:									 
									 return "Mobile";
							} 
 					}
				}


				 ///<summary>職 位</summary>
				public static string Employee_Position
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "职 位";
								 case "zh-HK":
									 return "職 位";
								  case "en-US":
									 return "Position";
 								 
 								 default:									 
									 return "Position";
							} 
 					}
				}


				 ///<summary>PositionId</summary>
				public static string Employee_PositionId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "PositionId";
								 case "zh-HK":
									 return "PositionId";
								  case "en-US":
									 return "PositionId";
 								 
 								 default:									 
									 return "PositionId";
							} 
 					}
				}


				 ///<summary>Position Title</summary>
				public static string Employee_PositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Position Title";
								 case "zh-HK":
									 return "Position Title";
								  case "en-US":
									 return "Position Title";
 								 
 								 default:									 
									 return "Position Title";
							} 
 					}
				}


				 ///<summary>備注</summary>
				public static string Employee_Remarks
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "备注";
								 case "zh-HK":
									 return "備注";
								  case "en-US":
									 return "備注";
 								 
 								 default:									 
									 return "備注";
							} 
 					}
				}


				 ///<summary>SiteId</summary>
				public static string Employee_SiteId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "SiteId";
								 case "zh-HK":
									 return "SiteId";
								  case "en-US":
									 return "SiteId";
 								 
 								 default:									 
									 return "SiteId";
							} 
 					}
				}


				 ///<summary>地盤名稱</summary>
				public static string Employee_SiteName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "地盤名稱";
								 case "zh-HK":
									 return "地盤名稱";
								  case "en-US":
									 return "Site Name";
 								 
 								 default:									 
									 return "Site Name";
							} 
 					}
				}


				 ///<summary>The 3rd Party EmployeeID</summary>
				public static string Employee_The3rdPartyEmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "The 3rd Party EmployeeID";
								 case "zh-HK":
									 return "The 3rd Party EmployeeID";
								  case "en-US":
									 return "The 3rd Party EmployeeID";
 								 
 								 default:									 
									 return "The 3rd Party EmployeeID";
							} 
 					}
				}


				 ///<summary>不存在的考勤編號</summary>
				public static string Employee_ThisEmployeeIdIsNotExist
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "不存在的考勤工号";
								 case "zh-HK":
									 return "不存在的考勤編號";
								  case "en-US":
									 return "This EmployeeId is not exist";
 								 
 								 default:									 
									 return "This EmployeeId is not exist";
							} 
 					}
				}


				 ///<summary>UserIcon</summary>
				public static string Employee_UserIcon
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "UserIcon";
								 case "zh-HK":
									 return "UserIcon";
								  case "en-US":
									 return "UserIcon";
 								 
 								 default:									 
									 return "UserIcon";
							} 
 					}
				}


				 ///<summary>UserId</summary>
				public static string Employee_UserId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "UserId";
								 case "zh-HK":
									 return "UserId";
								  case "en-US":
									 return "UserId";
 								 
 								 default:									 
									 return "UserId";
							} 
 					}
				}


				 ///<summary>請填入個人識別碼。</summary>
				public static string EmployeeDetails_AccessCardId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请填入个人识别码。";
								 case "zh-HK":
									 return "請填入個人識別碼。";
								  case "en-US":
									 return "Please input personal Access Id.";
 								 
 								 default:									 
									 return "Please input personal Access Id.";
							} 
 					}
				}


				 ///<summary>新增成功</summary>
				public static string EmployeeDetails_AddNewSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新增成功";
								 case "zh-HK":
									 return "新增成功";
								  case "en-US":
									 return "Add New Sucess !";
 								 
 								 default:									 
									 return "Add New Sucess !";
							} 
 					}
				}


				 ///<summary>關聯到用戶成功</summary>
				public static string EmployeeDetails_AssociateToUser_Success
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "关联到用户成功";
								 case "zh-HK":
									 return "關聯到用戶成功";
								  case "en-US":
									 return "It is successful to associate employee with system user!";
 								 
 								 default:									 
									 return "It is successful to associate employee with system user!";
							} 
 					}
				}


				 ///<summary>基本資料</summary>
				public static string EmployeeDetails_BasicPersonalDetail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "基本资料";
								 case "zh-HK":
									 return "基本資料";
								  case "en-US":
									 return "Basic Personal Detail";
 								 
 								 default:									 
									 return "Basic Personal Detail";
							} 
 					}
				}


				 ///<summary>取消系統用戶關聯成功</summary>
				public static string EmployeeDetails_CancelRelateToUser_Success
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "取消系统用户关联成功";
								 case "zh-HK":
									 return "取消系統用戶關聯成功";
								  case "en-US":
									 return "It is successful to cancel relation to user !";
 								 
 								 default:									 
									 return "It is successful to cancel relation to user !";
							} 
 					}
				}


				 ///<summary>如果沒有中文名字，則請填入英文名字</summary>
				public static string EmployeeDetails_CnNameTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "如果没有中文名字，则请填入英文名字";
								 case "zh-HK":
									 return "如果沒有中文名字，則請填入英文名字";
								  case "en-US":
									 return "If there is no Chinese name, please fill in the English name";
 								 
 								 default:									 
									 return "If there is no Chinese name, please fill in the English name";
							} 
 					}
				}


				 ///<summary>請選擇那一個部門。</summary>
				public static string EmployeeDetails_DepartmentId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请选择那一个部门。";
								 case "zh-HK":
									 return "請選擇那一個部門。";
								  case "en-US":
									 return "Please select which department.";
 								 
 								 default:									 
									 return "Please select which department.";
							} 
 					}
				}


				 ///<summary>當前已經存在系統用戶記錄，請通過系統用戶列表查詢。</summary>
				public static string EmployeeDetails_FailAsHasExistsEmployRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当前已经存在系统用户记录，请通过系统用户列表查询。";
								 case "zh-HK":
									 return "當前已經存在系統用戶記錄，請通過系統用戶列表查詢。";
								  case "en-US":
									 return "The system user record already exists. Please query through the system user list.";
 								 
 								 default:									 
									 return "The system user record already exists. Please query through the system user list.";
							} 
 					}
				}


				 ///<summary>處于在職狀態下，必須保持與入職登記日期（EnrollmentDate）一致。</summary>
				public static string EmployeeDetails_LeaveDateTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "处于在职状态下，必须保持与入职登记日期（EnrollmentDate）一致。";
								 case "zh-HK":
									 return "處于在職狀態下，必須保持與入職登記日期（EnrollmentDate）一致。";
								  case "en-US":
									 return "In the active position, it must remain consistent with the Enrollment Date.";
 								 
 								 default:									 
									 return "In the active position, it must remain consistent with the Enrollment Date.";
							} 
 					}
				}


				 ///<summary>無法將新設備用戶提交到終端。</summary>
				public static string EmployeeDetails_TerminalDeviceIdSyncResultFail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无法将新设备用户提交到终端。";
								 case "zh-HK":
									 return "無法將新設備用戶提交到終端。";
								  case "en-US":
									 return "Fail to Submit a new device User to terminal.";
 								 
 								 default:									 
									 return "Fail to Submit a new device User to terminal.";
							} 
 					}
				}


				 ///<summary>成功提交用戶終端設備記錄待執行。</summary>
				public static string EmployeeDetails_TerminalDeviceIdSyncResultOK
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "成功提交用户终端设备记录待执行。";
								 case "zh-HK":
									 return "成功提交用戶終端設備記錄待執行。";
								  case "en-US":
									 return "Submit a new device User to terminal in queue.";
 								 
 								 default:									 
									 return "Submit a new device User to terminal in queue.";
							} 
 					}
				}


				 ///<summary>雇員入職資料</summary>
				public static string EmployeeDetails_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "雇员入职资料";
								 case "zh-HK":
									 return "雇員入職資料";
								  case "en-US":
									 return "Employee Detail";
 								 
 								 default:									 
									 return "Employee Detail";
							} 
 					}
				}


				 ///<summary>更新失敗</summary>
				public static string EmployeeDetails_UpdateFailure
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "更新失败";
								 case "zh-HK":
									 return "更新失敗";
								  case "en-US":
									 return "Update Fail ！";
 								 
 								 default:									 
									 return "Update Fail ！";
							} 
 					}
				}


				 ///<summary>更新成功</summary>
				public static string EmployeeDetails_UpdateSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "更新成功";
								 case "zh-HK":
									 return "更新成功";
								  case "en-US":
									 return "Update Sucess !";
 								 
 								 default:									 
									 return "Update Sucess !";
							} 
 					}
				}


				 ///<summary>請假</summary>
				public static string EmployeeList_Leave
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假";
								 case "zh-HK":
									 return "請假";
								  case "en-US":
									 return "Leave Apply";
 								 
 								 default:									 
									 return "Leave Apply";
							} 
 					}
				}


				 ///<summary>雇員列表</summary>
				public static string EmployeeList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "雇员列表";
								 case "zh-HK":
									 return "雇員列表";
								  case "en-US":
									 return "Employee List";
 								 
 								 default:									 
									 return "Employee List";
							} 
 					}
				}


				 ///<summary>請先建立檔案，錄入最基本的姓名資料</summary>
				public static string EmployeeQuick_Message
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先建立档案，录入最基本的姓名资料";
								 case "zh-HK":
									 return "請先建立檔案，錄入最基本的姓名資料";
								  case "en-US":
									 return "Please build the document,input the full first!";
 								 
 								 default:									 
									 return "Please build the document,input the full first!";
							} 
 					}
				}


				 ///<summary>請輸入有效的EMail或者空白</summary>
				public static string EmployeeQuickAdd_EmailIsNotValidOrBlank
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效的EMail或者空白";
								 case "zh-HK":
									 return "請輸入有效的EMail或者空白";
								  case "en-US":
									 return "Email Is Not Valid Or Blank";
 								 
 								 default:									 
									 return "Email Is Not Valid Or Blank";
							} 
 					}
				}


				 ///<summary>入職日期格式不對</summary>
				public static string EmployeeQuickAdd_EnrollmentDateTimeIsInvalid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "入职日期格式不对";
								 case "zh-HK":
									 return "入職日期格式不對";
								  case "en-US":
									 return "Enrollment Date Is Invalid";
 								 
 								 default:									 
									 return "Enrollment Date Is Invalid";
							} 
 					}
				}


				 ///<summary>基本資料</summary>
				public static string EmployeeQuickAdd_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "基本资料";
								 case "zh-HK":
									 return "基本資料";
								  case "en-US":
									 return "Basic Info";
 								 
 								 default:									 
									 return "Basic Info";
							} 
 					}
				}


				 ///<summary>基本資料</summary>
				public static string EmployeeQuickHeader_BasicInfoAdd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "基本资料";
								 case "zh-HK":
									 return "基本資料";
								  case "en-US":
									 return "Basic Info";
 								 
 								 default:									 
									 return "Basic Info";
							} 
 					}
				}


				 ///<summary>卡號{0}已經被{1}({2})占用</summary>
				public static string EmployeeQuickReco_AccessCardIdOccupied
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "卡号{0}已经被{1}({2})占用";
								 case "zh-HK":
									 return "卡號{0}已經被{1}({2})占用";
								  case "en-US":
									 return "Access card No {0} was occupied by {1}({2})";
 								 
 								 default:									 
									 return "Access card No {0} was occupied by {1}({2})";
							} 
 					}
				}


				 ///<summary>四大皆空啊！無效的操作，或者下一步吧！</summary>
				public static string EmployeeQuickReco_IsAllBlank
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "四大皆空啊！无效的操作，或者下一步吧！";
								 case "zh-HK":
									 return "四大皆空啊！無效的操作，或者下一步吧！";
								  case "en-US":
									 return "The Operation is Invalid, you may click the next step!";
 								 
 								 default:									 
									 return "The Operation is Invalid, you may click the next step!";
							} 
 					}
				}


				 ///<summary>沒有有效的EmployeeId，請先創建基本資料</summary>
				public static string EmployeeQuickReco_NoEmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有有效的EmployeeId，请先创建基本资料";
								 case "zh-HK":
									 return "沒有有效的EmployeeId，請先創建基本資料";
								  case "en-US":
									 return "NoEmployeeId，Build Employee Basic Info First！";
 								 
 								 default:									 
									 return "NoEmployeeId，Build Employee Basic Info First！";
							} 
 					}
				}


				 ///<summary>識別特征</summary>
				public static string EmployeeQuickReco_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "识别特征";
								 case "zh-HK":
									 return "識別特征";
								  case "en-US":
									 return "Recognition";
 								 
 								 default:									 
									 return "Recognition";
							} 
 					}
				}


				 ///<summary>已存在相同日期范圍的請假</summary>
				public static string ErrorCode10002
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已存在相同日期范围的请假";
								 case "zh-HK":
									 return "已存在相同日期范圍的請假";
								  case "en-US":
									 return "Existed the same leave";
 								 
 								 default:									 
									 return "Existed the same leave";
							} 
 					}
				}


				 ///<summary>發生服務器內容錯誤！</summary>
				public static string ErrorCode10004
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "发生服务器内容错误！";
								 case "zh-HK":
									 return "發生服務器內容錯誤！";
								  case "en-US":
									 return "Occur server internal error";
 								 
 								 default:									 
									 return "Occur server internal error";
							} 
 					}
				}


				 ///<summary>沒有必要的參數（考勤編號）</summary>
				public static string ErrorCode10007
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有必要的参数（考勤编号）";
								 case "zh-HK":
									 return "沒有必要的參數（考勤編號）";
								  case "en-US":
									 return "Need the params:AttendanceId(EmployeeId)";
 								 
 								 default:									 
									 return "Need the params:AttendanceId(EmployeeId)";
							} 
 					}
				}


				 ///<summary>似乎非工作天或沒有安排班期</summary>
				public static string ErrorCode1001
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "似乎非工作天或没有安排班期";
								 case "zh-HK":
									 return "似乎非工作天或沒有安排班期";
								  case "en-US":
									 return "It does not look like a work day!";
 								 
 								 default:									 
									 return "It does not look like a work day!";
							} 
 					}
				}


				 ///<summary>時間范圍不正確，請按照排班設置的上班時間和下班時間！系統自動填入對應的上下班時間！</summary>
				public static string ErrorCode1006
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "时间范围不正确，请按照排班设置的上班时间和下班时间！系统自动填入对应的上下班时间！";
								 case "zh-HK":
									 return "時間范圍不正確，請按照排班設置的上班時間和下班時間！系統自動填入對應的上下班時間！";
								  case "en-US":
									 return "The date time range is incorrect. Please follow the workon time and workoff time set by the shift! The system has automatically filled in the corresponding commute time!";
 								 
 								 default:									 
									 return "The date time range is incorrect. Please follow the workon time and workoff time set by the shift! The system has automatically filled in the corresponding commute time!";
							} 
 					}
				}


				 ///<summary>文件上載失敗</summary>
				public static string FILE_UPLOAD_FAIL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "文件上载失败";
								 case "zh-HK":
									 return "文件上載失敗";
								  case "en-US":
									 return "Fail to upload !";
 								 
 								 default:									 
									 return "Fail to upload !";
							} 
 					}
				}


				 ///<summary>文件上載成功</summary>
				public static string FILE_UPLOAD_SUCCESS
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "文件上载成功";
								 case "zh-HK":
									 return "文件上載成功";
								  case "en-US":
									 return "Successful to upload !";
 								 
 								 default:									 
									 return "Successful to upload !";
							} 
 					}
				}


				 ///<summary>文件尺寸限制</summary>
				public static string FILESIZE_IS_LIMITED
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "文件尺寸限制";
								 case "zh-HK":
									 return "文件尺寸限制";
								  case "en-US":
									 return "File size is limited !";
 								 
 								 default:									 
									 return "File size is limited !";
							} 
 					}
				}


				 ///<summary>行業字典已經存在</summary>
				public static string FoundationData_ExistIndustryIdKeyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业字典已经存在";
								 case "zh-HK":
									 return "行業字典已經存在";
								  case "en-US":
									 return "Exist IndustryId KeyName";
 								 
 								 default:									 
									 return "Exist IndustryId KeyName";
							} 
 					}
				}


				 ///<summary>KeyName字典不存在</summary>
				public static string FoundationData_LangDetails_NotExistKeyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "KeyName字典不存在";
								 case "zh-HK":
									 return "KeyName字典不存在";
								  case "en-US":
									 return "Not Exist KeyName";
 								 
 								 default:									 
									 return "Not Exist KeyName";
							} 
 					}
				}


				 ///<summary>女</summary>
				public static string Genders_FEMALE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "女";
								 case "zh-HK":
									 return "女";
								  case "en-US":
									 return "FEMALE";
 								 
 								 default:									 
									 return "FEMALE";
							} 
 					}
				}


				 ///<summary>男</summary>
				public static string Genders_MALE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "男";
								 case "zh-HK":
									 return "男";
								  case "en-US":
									 return "MALE";
 								 
 								 default:									 
									 return "MALE";
							} 
 					}
				}


				 ///<summary>未知</summary>
				public static string Genders_UNKOWN
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "未知";
								 case "zh-HK":
									 return "未知";
								  case "en-US":
									 return "UNKOWN";
 								 
 								 default:									 
									 return "UNKOWN";
							} 
 					}
				}


				 ///<summary>一般假期</summary>
				public static string GENERAL_LEAVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "一般假期";
								 case "zh-HK":
									 return "一般假期";
								  case "en-US":
									 return "GENERAL LEAVE";
 								 
 								 default:									 
									 return "GENERAL LEAVE";
							} 
 					}
				}


				 ///<summary>About Us</summary>
				public static string GeneralUI_About
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "About Us";
								 case "zh-HK":
									 return "About Us";
								  case "en-US":
									 return "About Us";
 								 
 								 default:									 
									 return "About Us";
							} 
 					}
				}


				 ///<summary>沒有訪問權限</summary>
				public static string GeneralUI_AccessDenied
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有访问权限";
								 case "zh-HK":
									 return "沒有訪問權限";
								  case "en-US":
									 return "Access Denied";
 								 
 								 default:									 
									 return "Access Denied";
							} 
 					}
				}


				 ///<summary>累计</summary>
				public static string GeneralUI_Accumulate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "累计";
								 case "zh-HK":
									 return "累计";
								  case "en-US":
									 return "Accu";
 								 
 								 default:									 
									 return "Accu";
							} 
 					}
				}


				 ///<summary>使用中</summary>
				public static string GeneralUI_ACTIVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "使用中";
								 case "zh-HK":
									 return "使用中";
								  case "en-US":
									 return "Active";
 								 
 								 default:									 
									 return "Active";
							} 
 					}
				}


				 ///<summary>新 增</summary>
				public static string GeneralUI_AddNew
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新 增";
								 case "zh-HK":
									 return "新 增";
								  case "en-US":
									 return "Add New";
 								 
 								 default:									 
									 return "Add New";
							} 
 					}
				}


				 ///<summary>和</summary>
				public static string GeneralUI_AND
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "和";
								 case "zh-HK":
									 return "和";
								  case "en-US":
									 return "and";
 								 
 								 default:									 
									 return "and";
							} 
 					}
				}


				 ///<summary>批准</summary>
				public static string GeneralUI_Approved
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "批准";
								 case "zh-HK":
									 return "批准";
								  case "en-US":
									 return "Approved";
 								 
 								 default:									 
									 return "Approved";
							} 
 					}
				}


				 ///<summary>升序</summary>
				public static string GeneralUI_ASC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "升序";
								 case "zh-HK":
									 return "升序";
								  case "en-US":
									 return "ASC";
 								 
 								 default:									 
									 return "ASC";
							} 
 					}
				}


				 ///<summary>考勤</summary>
				public static string GeneralUI_Attendance
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤";
								 case "zh-HK":
									 return "考勤";
								  case "en-US":
									 return "Attendance";
 								 
 								 default:									 
									 return "Attendance";
							} 
 					}
				}


				 ///<summary>考勤系統</summary>
				public static string GeneralUI_AttendanceSystem
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤系统";
								 case "zh-HK":
									 return "考勤系統";
								  case "en-US":
									 return "Attendance System";
 								 
 								 default:									 
									 return "Attendance System";
							} 
 					}
				}


				 ///<summary>錯誤的用戶名或密碼</summary>
				public static string GeneralUI_AUTH_WRONG_USERNAME_OR_PASSWORD
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "错误的用户名或密码";
								 case "zh-HK":
									 return "錯誤的用戶名或密碼";
								  case "en-US":
									 return "Username or password is incorrect!";
 								 
 								 default:									 
									 return "Username or password is incorrect!";
							} 
 					}
				}


				 ///<summary>平均</summary>
				public static string GeneralUI_Average
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "平均";
								 case "zh-HK":
									 return "平均";
								  case "en-US":
									 return "Avg";
 								 
 								 default:									 
									 return "Avg";
							} 
 					}
				}


				 ///<summary>瀏 覽</summary>
				public static string GeneralUI_Browse
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "浏 览";
								 case "zh-HK":
									 return "瀏 覽";
								  case "en-US":
									 return "Browse";
 								 
 								 default:									 
									 return "Browse";
							} 
 					}
				}


				 ///<summary>取 消</summary>
				public static string GeneralUI_Cancel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "取 消";
								 case "zh-HK":
									 return "取 消";
								  case "en-US":
									 return "Cancel";
 								 
 								 default:									 
									 return "Cancel";
							} 
 					}
				}


				 ///<summary>檢測數據安全性，红色为篡改過的。</summary>
				public static string GeneralUI_CheckDataSecurity
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "检测数据安全性，红色为篡改过的。";
								 case "zh-HK":
									 return "檢測數據安全性，红色为篡改過的。";
								  case "en-US":
									 return "Check data security,The Red signed  distorted.";
 								 
 								 default:									 
									 return "Check data security,The Red signed  distorted.";
							} 
 					}
				}


				 ///<summary>點擊復制</summary>
				public static string GeneralUI_ClickToCopy
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "点击复制";
								 case "zh-HK":
									 return "點擊復制";
								  case "en-US":
									 return "Click to copy";
 								 
 								 default:									 
									 return "Click to copy";
							} 
 					}
				}


				 ///<summary>客戶端</summary>
				public static string GeneralUI_Client
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "客户端";
								 case "zh-HK":
									 return "客戶端";
								  case "en-US":
									 return "Client";
 								 
 								 default:									 
									 return "Client";
							} 
 					}
				}


				 ///<summary>中文姓名</summary>
				public static string GeneralUI_CnName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "中文姓名";
								 case "zh-HK":
									 return "中文姓名";
								  case "en-US":
									 return "Chinese Name";
 								 
 								 default:									 
									 return "Chinese Name";
							} 
 					}
				}


				 ///<summary>確 認</summary>
				public static string GeneralUI_Comfirmed
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确 认";
								 case "zh-HK":
									 return "確 認";
								  case "en-US":
									 return "Comfirmed";
 								 
 								 default:									 
									 return "Comfirmed";
							} 
 					}
				}


				 ///<summary>ComfirmedPassword</summary>
				public static string GeneralUI_ComfirmedPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ComfirmedPassword";
								 case "zh-HK":
									 return "ComfirmedPassword";
								  case "en-US":
									 return "ComfirmedPassword";
 								 
 								 default:									 
									 return "ComfirmedPassword";
							} 
 					}
				}


				 ///<summary>如果刪除，會影響數據完整性！</summary>
				public static string GeneralUI_ComfirmTipsIfDelete
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "如果删除，会影响数据完整性！";
								 case "zh-HK":
									 return "如果刪除，會影響數據完整性！";
								  case "en-US":
									 return "If deleted, it will affect data integrity!";
 								 
 								 default:									 
									 return "If deleted, it will affect data integrity!";
							} 
 					}
				}


				 ///<summary>確認您的電子郵件時出錯。</summary>
				public static string GeneralUI_ConfirmingEmailError
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认您的电子邮件时出错。";
								 case "zh-HK":
									 return "確認您的電子郵件時出錯。";
								  case "en-US":
									 return "Error confirming your email.";
 								 
 								 default:									 
									 return "Error confirming your email.";
							} 
 					}
				}


				 ///<summary>確認密碼</summary>
				public static string GeneralUI_ConfirmPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认密码";
								 case "zh-HK":
									 return "確認密碼";
								  case "en-US":
									 return "Confirmed Password";
 								 
 								 default:									 
									 return "Confirmed Password";
							} 
 					}
				}


				 ///<summary>聯 系</summary>
				public static string GeneralUI_Contact
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "联 系";
								 case "zh-HK":
									 return "聯 系";
								  case "en-US":
									 return "Contact Us";
 								 
 								 default:									 
									 return "Contact Us";
							} 
 					}
				}


				 ///<summary>繼續</summary>
				public static string GeneralUI_Continue
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "继续";
								 case "zh-HK":
									 return "繼續";
								  case "en-US":
									 return "Continue";
 								 
 								 default:									 
									 return "Continue";
							} 
 					}
				}


				 ///<summary>創 建</summary>
				public static string GeneralUI_Create
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "创 建";
								 case "zh-HK":
									 return "創 建";
								  case "en-US":
									 return "Create";
 								 
 								 default:									 
									 return "Create";
							} 
 					}
				}


				 ///<summary>$</summary>
				public static string GeneralUI_CurrencySymbol
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "￥";
								 case "zh-HK":
									 return "$";
								  case "en-US":
									 return "$";
 								 
 								 default:									 
									 return "$";
							} 
 					}
				}


				 ///<summary>數據發送中......</summary>
				public static string GeneralUI_DataSending
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "数据发送中......";
								 case "zh-HK":
									 return "數據發送中......";
								  case "en-US":
									 return "Data Sending......";
 								 
 								 default:									 
									 return "Data Sending......";
							} 
 					}
				}


				 ///<summary>請輸入有效的日期格式</summary>
				public static string GeneralUI_Date
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效的日期格式";
								 case "zh-HK":
									 return "請輸入有效的日期格式";
								  case "en-US":
									 return "Please input valid date";
 								 
 								 default:									 
									 return "Please input valid date";
							} 
 					}
				}


				 ///<summary>yyyy-mm-dd</summary>
				public static string GeneralUI_DateFormate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "yyyy-mm-dd";
								 case "zh-HK":
									 return "yyyy-mm-dd";
								  case "en-US":
									 return "yyyy-mm-dd";
 								 
 								 default:									 
									 return "yyyy-mm-dd";
							} 
 					}
				}


				 ///<summary>yyyy-MM-dd</summary>
				public static string GeneralUI_DateRangeFormat
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "yyyy-MM-dd";
								 case "zh-HK":
									 return "yyyy-MM-dd";
								  case "en-US":
									 return "yyyy-MM-dd";
 								 
 								 default:									 
									 return "yyyy-MM-dd";
							} 
 					}
				}


				 ///<summary>後天</summary>
				public static string GeneralUI_DateTime_Acquired
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "后天";
								 case "zh-HK":
									 return "後天";
								  case "en-US":
									 return "Acquired";
 								 
 								 default:									 
									 return "Acquired";
							} 
 					}
				}


				 ///<summary>自定義日期</summary>
				public static string GeneralUI_DateTime_CustomDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自定义日期";
								 case "zh-HK":
									 return "自定義日期";
								  case "en-US":
									 return "Custom Date";
 								 
 								 default:									 
									 return "Custom Date";
							} 
 					}
				}


				 ///<summary>結束時間</summary>
				public static string GeneralUI_DateTime_EndTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "結束时间";
								 case "zh-HK":
									 return "結束時間";
								  case "en-US":
									 return "End time";
 								 
 								 default:									 
									 return "End time";
							} 
 					}
				}


				 ///<summary>小時</summary>
				public static string GeneralUI_DateTime_Hour
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "小时";
								 case "zh-HK":
									 return "小時";
								  case "en-US":
									 return "Hour";
 								 
 								 default:									 
									 return "Hour";
							} 
 					}
				}


				 ///<summary>最近30天</summary>
				public static string GeneralUI_DateTime_Last30Days
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "最近30天";
								 case "zh-HK":
									 return "最近30天";
								  case "en-US":
									 return "Last 30 Days";
 								 
 								 default:									 
									 return "Last 30 Days";
							} 
 					}
				}


				 ///<summary>最近7天</summary>
				public static string GeneralUI_DateTime_Last7Days
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "最近7天";
								 case "zh-HK":
									 return "最近7天";
								  case "en-US":
									 return "Last 7 Days";
 								 
 								 default:									 
									 return "Last 7 Days";
							} 
 					}
				}


				 ///<summary>分鐘</summary>
				public static string GeneralUI_DateTime_Minute
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "分钟";
								 case "zh-HK":
									 return "分鐘";
								  case "en-US":
									 return "Minute";
 								 
 								 default:									 
									 return "Minute";
							} 
 					}
				}


				 ///<summary>過兩周后</summary>
				public static string GeneralUI_DateTime_NextTwoWeek
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "过两周后";
								 case "zh-HK":
									 return "過兩周后";
								  case "en-US":
									 return "Next Two Week";
 								 
 								 default:									 
									 return "Next Two Week";
							} 
 					}
				}


				 ///<summary>下週</summary>
				public static string GeneralUI_DateTime_NextWeek
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下周";
								 case "zh-HK":
									 return "下週";
								  case "en-US":
									 return "NextWeek";
 								 
 								 default:									 
									 return "NextWeek";
							} 
 					}
				}


				 ///<summary>秒</summary>
				public static string GeneralUI_DateTime_Second
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "秒";
								 case "zh-HK":
									 return "秒";
								  case "en-US":
									 return "Second";
 								 
 								 default:									 
									 return "Second";
							} 
 					}
				}


				 ///<summary>起始時間</summary>
				public static string GeneralUI_DateTime_StartTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "起始时间";
								 case "zh-HK":
									 return "起始時間";
								  case "en-US":
									 return "Start time";
 								 
 								 default:									 
									 return "Start time";
							} 
 					}
				}


				 ///<summary>今天</summary>
				public static string GeneralUI_DateTime_Today
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "今天";
								 case "zh-HK":
									 return "今天";
								  case "en-US":
									 return "Today";
 								 
 								 default:									 
									 return "Today";
							} 
 					}
				}


				 ///<summary>明天</summary>
				public static string GeneralUI_DateTime_Tomorrow
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "明天";
								 case "zh-HK":
									 return "明天";
								  case "en-US":
									 return "Tomorrow";
 								 
 								 default:									 
									 return "Tomorrow";
							} 
 					}
				}


				 ///<summary>昨天</summary>
				public static string GeneralUI_DateTime_Yesterday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "昨天";
								 case "zh-HK":
									 return "昨天";
								  case "en-US":
									 return "Yesterday";
 								 
 								 default:									 
									 return "Yesterday";
							} 
 					}
				}


				 ///<summary>HH:mm\nyyyy-MM-dd</summary>
				public static string GeneralUI_DateTimeAheadFormat
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "HH:mm\nyyyy-MM-dd";
								 case "zh-HK":
									 return "HH:mm\nyyyy-MM-dd";
								  case "en-US":
									 return "HH:mm\nyyyy-MM-dd";
 								 
 								 default:									 
									 return "HH:mm\nyyyy-MM-dd";
							} 
 					}
				}


				 ///<summary>yyyy-MM-dd HH:mm</summary>
				public static string GeneralUI_DateTimeFormat
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "yyyy-MM-dd HH:mm";
								 case "zh-HK":
									 return "yyyy-MM-dd HH:mm";
								  case "en-US":
									 return "yyyy-MM-dd HH:mm";
 								 
 								 default:									 
									 return "yyyy-MM-dd HH:mm";
							} 
 					}
				}


				 ///<summary>yyyy-mm-dd hh:ii:ss</summary>
				public static string GeneralUI_DateTimePickerFormatJS
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "yyyy-mm-dd hh:ii:ss";
								 case "zh-HK":
									 return "yyyy-mm-dd hh:ii:ss";
								  case "en-US":
									 return "yyyy-mm-dd hh:ii:ss";
 								 
 								 default:									 
									 return "yyyy-mm-dd hh:ii:ss";
							} 
 					}
				}


				 ///<summary>日期(時間)范圍</summary>
				public static string GeneralUI_DateTimeRange
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日期(时间)范围";
								 case "zh-HK":
									 return "日期(時間)范圍";
								  case "en-US":
									 return "Date (Time) Range";
 								 
 								 default:									 
									 return "Date (Time) Range";
							} 
 					}
				}


				 ///<summary>YYYY-MM-DDTHH:mm</summary>
				public static string GeneralUI_DateTimeRangeFormatJS
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "YYYY-MM-DDTHH:mm";
								 case "zh-HK":
									 return "YYYY-MM-DDTHH:mm";
								  case "en-US":
									 return "YYYY-MM-DDTHH:mm";
 								 
 								 default:									 
									 return "YYYY-MM-DDTHH:mm";
							} 
 					}
				}


				 ///<summary>天</summary>
				public static string GeneralUI_Day
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "天";
								 case "zh-HK":
									 return "天";
								  case "en-US":
									 return "Day";
 								 
 								 default:									 
									 return "Day";
							} 
 					}
				}


				 ///<summary>每日</summary>
				public static string GeneralUI_DAYLY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每日";
								 case "zh-HK":
									 return "每日";
								  case "en-US":
									 return "DAYLY";
 								 
 								 default:									 
									 return "DAYLY";
							} 
 					}
				}


				 ///<summary>五</summary>
				public static string GeneralUI_DayOfWeekAbbr_Friday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "五";
								 case "zh-HK":
									 return "五";
								  case "en-US":
									 return "Fr";
 								 
 								 default:									 
									 return "Fr";
							} 
 					}
				}


				 ///<summary>一</summary>
				public static string GeneralUI_DayOfWeekAbbr_Monday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "一";
								 case "zh-HK":
									 return "一";
								  case "en-US":
									 return "Mo";
 								 
 								 default:									 
									 return "Mo";
							} 
 					}
				}


				 ///<summary>六</summary>
				public static string GeneralUI_DayOfWeekAbbr_Saturday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "六";
								 case "zh-HK":
									 return "六";
								  case "en-US":
									 return "Sa";
 								 
 								 default:									 
									 return "Sa";
							} 
 					}
				}


				 ///<summary>日</summary>
				public static string GeneralUI_DayOfWeekAbbr_Sunday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日";
								 case "zh-HK":
									 return "日";
								  case "en-US":
									 return "Su";
 								 
 								 default:									 
									 return "Su";
							} 
 					}
				}


				 ///<summary>四</summary>
				public static string GeneralUI_DayOfWeekAbbr_Thursday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "四";
								 case "zh-HK":
									 return "四";
								  case "en-US":
									 return "Th";
 								 
 								 default:									 
									 return "Th";
							} 
 					}
				}


				 ///<summary>二</summary>
				public static string GeneralUI_DayOfWeekAbbr_Tuesday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "二";
								 case "zh-HK":
									 return "二";
								  case "en-US":
									 return "Tu";
 								 
 								 default:									 
									 return "Tu";
							} 
 					}
				}


				 ///<summary>三</summary>
				public static string GeneralUI_DayOfWeekAbbr_Wednesday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "三";
								 case "zh-HK":
									 return "三";
								  case "en-US":
									 return "We";
 								 
 								 default:									 
									 return "We";
							} 
 					}
				}


				 ///<summary>操作數據庫出錯</summary>
				public static string GeneralUI_DbFail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作数据库出错";
								 case "zh-HK":
									 return "操作數據庫出錯";
								  case "en-US":
									 return "Database Occured error!";
 								 
 								 default:									 
									 return "Database Occured error!";
							} 
 					}
				}


				 ///<summary>雙擊重選</summary>
				public static string GeneralUI_DblClkToSelect
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "双击重选";
								 case "zh-HK":
									 return "雙擊重選";
								  case "en-US":
									 return "Double Click to Re-select";
 								 
 								 default:									 
									 return "Double Click to Re-select";
							} 
 					}
				}


				 ///<summary>刪 除</summary>
				public static string GeneralUI_Delete
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "删 除";
								 case "zh-HK":
									 return "刪 除";
								  case "en-US":
									 return "Delete";
 								 
 								 default:									 
									 return "Delete";
							} 
 					}
				}


				 ///<summary>降序</summary>
				public static string GeneralUI_DESC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "降序";
								 case "zh-HK":
									 return "降序";
								  case "en-US":
									 return "DESC";
 								 
 								 default:									 
									 return "DESC";
							} 
 					}
				}


				 ///<summary>詳 情</summary>
				public static string GeneralUI_Details
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "详 情";
								 case "zh-HK":
									 return "詳 情";
								  case "en-US":
									 return "Details";
 								 
 								 default:									 
									 return "Details";
							} 
 					}
				}


				 ///<summary>設備</summary>
				public static string GeneralUI_Device
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设备";
								 case "zh-HK":
									 return "設備";
								  case "en-US":
									 return "Device";
 								 
 								 default:									 
									 return "Device";
							} 
 					}
				}


				 ///<summary>禁用</summary>
				public static string GeneralUI_Disable
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "禁用";
								 case "zh-HK":
									 return "禁用";
								  case "en-US":
									 return "Disable";
 								 
 								 default:									 
									 return "Disable";
							} 
 					}
				}


				 ///<summary>下載標準模板 Excel</summary>
				public static string GeneralUI_DownLoadStandardImport
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下载标准模板 Excel";
								 case "zh-HK":
									 return "下載標準模板 Excel";
								  case "en-US":
									 return "DownLoad Standard Import Excel";
 								 
 								 default:									 
									 return "DownLoad Standard Import Excel";
							} 
 					}
				}


				 ///<summary>編輯</summary>
				public static string GeneralUI_Edit
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "编辑";
								 case "zh-HK":
									 return "編輯";
								  case "en-US":
									 return "Edit";
 								 
 								 default:									 
									 return "Edit";
							} 
 					}
				}


				 ///<summary>Email</summary>
				public static string GeneralUI_Email
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email";
								 case "zh-HK":
									 return "Email";
								  case "en-US":
									 return "Email";
 								 
 								 default:									 
									 return "Email";
							} 
 					}
				}


				 ///<summary>考勤人員</summary>
				public static string GeneralUI_Employee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤人员";
								 case "zh-HK":
									 return "考勤人員";
								  case "en-US":
									 return "Attendance";
 								 
 								 default:									 
									 return "Attendance";
							} 
 					}
				}


				 ///<summary>英文名</summary>
				public static string GeneralUI_EnName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "英文名";
								 case "zh-HK":
									 return "英文名";
								  case "en-US":
									 return "Eng Name";
 								 
 								 default:									 
									 return "Eng Name";
							} 
 					}
				}


				 ///<summary>系統意外</summary>
				public static string GeneralUI_EXCEPTION
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统意外";
								 case "zh-HK":
									 return "系統意外";
								  case "en-US":
									 return "SYSTEM EXCEPTION";
 								 
 								 default:									 
									 return "SYSTEM EXCEPTION";
							} 
 					}
				}


				 ///<summary>已經存在</summary>
				public static string GeneralUI_Exist
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已经存在";
								 case "zh-HK":
									 return "已經存在";
								  case "en-US":
									 return "Exist";
 								 
 								 default:									 
									 return "Exist";
							} 
 					}
				}


				 ///<summary>存在可疑的篡改記錄！！！！</summary>
				public static string GeneralUI_ExistDataRecruitme
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在可疑的篡改记录！！！！";
								 case "zh-HK":
									 return "存在可疑的篡改記錄！！！！";
								  case "en-US":
									 return "Exist data recruitment";
 								 
 								 default:									 
									 return "Exist data recruitment";
							} 
 					}
				}


				 ///<summary>已存在的記錄</summary>
				public static string GeneralUI_ExitRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已存在的记录";
								 case "zh-HK":
									 return "已存在的記錄";
								  case "en-US":
									 return "Exited Record";
 								 
 								 default:									 
									 return "Exited Record";
							} 
 					}
				}


				 ///<summary>展開查看更多</summary>
				public static string GeneralUI_ExtendForMoreDetails
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "展开查看更多";
								 case "zh-HK":
									 return "展開查看更多";
								  case "en-US":
									 return "Extend For More Details";
 								 
 								 default:									 
									 return "Extend For More Details";
							} 
 					}
				}


				 ///<summary>失敗 !</summary>
				public static string GeneralUI_Fail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "失败 !";
								 case "zh-HK":
									 return "失敗 !";
								  case "en-US":
									 return "Fail ！";
 								 
 								 default:									 
									 return "Fail ！";
							} 
 					}
				}


				 ///<summary>否</summary>
				public static string GeneralUI_FALSE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "否";
								 case "zh-HK":
									 return "否";
								  case "en-US":
									 return "FALSE";
 								 
 								 default:									 
									 return "FALSE";
							} 
 					}
				}


				 ///<summary>狀態</summary>
				public static string GeneralUI_GeneralStatus
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "状态";
								 case "zh-HK":
									 return "狀態";
								  case "en-US":
									 return "Status";
 								 
 								 default:									 
									 return "Status";
							} 
 					}
				}


				 ///<summary>主 頁</summary>
				public static string GeneralUI_HomePage
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "主 页";
								 case "zh-HK":
									 return "主 頁";
								  case "en-US":
									 return "Home Page";
 								 
 								 default:									 
									 return "Home Page";
							} 
 					}
				}


				 ///<summary>停用中</summary>
				public static string GeneralUI_INACTIVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "停用中";
								 case "zh-HK":
									 return "停用中";
								  case "en-US":
									 return "Inactive";
 								 
 								 default:									 
									 return "Inactive";
							} 
 					}
				}


				 ///<summary>信息提示</summary>
				public static string GeneralUI_InfoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "信息提示";
								 case "zh-HK":
									 return "信息提示";
								  case "en-US":
									 return "InfoTips";
 								 
 								 default:									 
									 return "InfoTips";
							} 
 					}
				}


				 ///<summary>I see</summary>
				public static string GeneralUI_Isee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "I see";
								 case "zh-HK":
									 return "I see";
								  case "en-US":
									 return "I see";
 								 
 								 default:									 
									 return "I see";
							} 
 					}
				}


				 ///<summary>列表</summary>
				public static string GeneralUI_List
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "列表";
								 case "zh-HK":
									 return "列表";
								  case "en-US":
									 return "List";
 								 
 								 default:									 
									 return "List";
							} 
 					}
				}


				 ///<summary>查詢列表無記錄</summary>
				public static string GeneralUI_ListNoRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "查?列表???";
								 case "zh-HK":
									 return "查詢列表無記錄";
								  case "en-US":
									 return "List No Record";
 								 
 								 default:									 
									 return "List No Record";
							} 
 					}
				}


				 ///<summary>Login</summary>
				public static string GeneralUI_Login
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登陸";
								 case "zh-HK":
									 return "Login";
								  case "en-US":
									 return "Login";
 								 
 								 default:									 
									 return "Login";
							} 
 					}
				}


				 ///<summary>登錄賬戶</summary>
				public static string GeneralUI_LoginAccountNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登录账户";
								 case "zh-HK":
									 return "登錄賬戶";
								  case "en-US":
									 return "Login Account";
 								 
 								 default:									 
									 return "Login Account";
							} 
 					}
				}


				 ///<summary>登錄失敗</summary>
				public static string GeneralUI_LoginFail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登录失败";
								 case "zh-HK":
									 return "登錄失敗";
								  case "en-US":
									 return "Login Fail!";
 								 
 								 default:									 
									 return "Login Fail!";
							} 
 					}
				}


				 ///<summary>登出</summary>
				public static string GeneralUI_Logout
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登出";
								 case "zh-HK":
									 return "登出";
								  case "en-US":
									 return "Logout";
 								 
 								 default:									 
									 return "Logout";
							} 
 					}
				}


				 ///<summary>商?ID(MainComId)不一致</summary>
				public static string GeneralUI_MainComIdIsNotConsistent
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "商?ID(MainComId)不一致";
								 case "zh-HK":
									 return "商?ID(MainComId)不一致";
								  case "en-US":
									 return "Merchant ID (MainComId) is inconsistent";
 								 
 								 default:									 
									 return "Merchant ID (MainComId) is inconsistent";
							} 
 					}
				}


				 ///<summary>需要正确的MainComId</summary>
				public static string GeneralUI_MainComIdRequired
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "需要正确的MainComId";
								 case "zh-HK":
									 return "需要正确的MainComId";
								  case "en-US":
									 return "Required correct MainComId";
 								 
 								 default:									 
									 return "Required correct MainComId";
							} 
 					}
				}


				 ///<summary>四月</summary>
				public static string GeneralUI_Month_April
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "四月";
								 case "zh-HK":
									 return "四月";
								  case "en-US":
									 return "Apr";
 								 
 								 default:									 
									 return "Apr";
							} 
 					}
				}


				 ///<summary>八月</summary>
				public static string GeneralUI_Month_August
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "八月";
								 case "zh-HK":
									 return "八月";
								  case "en-US":
									 return "Aug";
 								 
 								 default:									 
									 return "Aug";
							} 
 					}
				}


				 ///<summary>十二月</summary>
				public static string GeneralUI_Month_December
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "十二月";
								 case "zh-HK":
									 return "十二月";
								  case "en-US":
									 return "Dec";
 								 
 								 default:									 
									 return "Dec";
							} 
 					}
				}


				 ///<summary>二月</summary>
				public static string GeneralUI_Month_February
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "二月";
								 case "zh-HK":
									 return "二月";
								  case "en-US":
									 return "Feb";
 								 
 								 default:									 
									 return "Feb";
							} 
 					}
				}


				 ///<summary>一月</summary>
				public static string GeneralUI_Month_January
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "一月";
								 case "zh-HK":
									 return "一月";
								  case "en-US":
									 return "Jan";
 								 
 								 default:									 
									 return "Jan";
							} 
 					}
				}


				 ///<summary>七月</summary>
				public static string GeneralUI_Month_July
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "七月";
								 case "zh-HK":
									 return "七月";
								  case "en-US":
									 return "Jul";
 								 
 								 default:									 
									 return "Jul";
							} 
 					}
				}


				 ///<summary>六月</summary>
				public static string GeneralUI_Month_June
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "六月";
								 case "zh-HK":
									 return "六月";
								  case "en-US":
									 return "Jun";
 								 
 								 default:									 
									 return "Jun";
							} 
 					}
				}


				 ///<summary>三月</summary>
				public static string GeneralUI_Month_March
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "三月";
								 case "zh-HK":
									 return "三月";
								  case "en-US":
									 return "Mar";
 								 
 								 default:									 
									 return "Mar";
							} 
 					}
				}


				 ///<summary>五月</summary>
				public static string GeneralUI_Month_May
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "五月";
								 case "zh-HK":
									 return "五月";
								  case "en-US":
									 return "May";
 								 
 								 default:									 
									 return "May";
							} 
 					}
				}


				 ///<summary>十一月</summary>
				public static string GeneralUI_Month_November
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "十一月";
								 case "zh-HK":
									 return "十一月";
								  case "en-US":
									 return "Nov";
 								 
 								 default:									 
									 return "Nov";
							} 
 					}
				}


				 ///<summary>十月</summary>
				public static string GeneralUI_Month_October
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "十月";
								 case "zh-HK":
									 return "十月";
								  case "en-US":
									 return "Oct";
 								 
 								 default:									 
									 return "Oct";
							} 
 					}
				}


				 ///<summary>九月</summary>
				public static string GeneralUI_Month_September
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "九月";
								 case "zh-HK":
									 return "九月";
								  case "en-US":
									 return "Sep";
 								 
 								 default:									 
									 return "Sep";
							} 
 					}
				}


				 ///<summary>每月</summary>
				public static string GeneralUI_MONTHLY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每月";
								 case "zh-HK":
									 return "每月";
								  case "en-US":
									 return "MONTHLY";
 								 
 								 default:									 
									 return "MONTHLY";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string GeneralUI_Name
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Name";
 								 
 								 default:									 
									 return "Name";
							} 
 					}
				}


				 ///<summary>下一步</summary>
				public static string GeneralUI_Next
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下一步";
								 case "zh-HK":
									 return "下一步";
								  case "en-US":
									 return "Next";
 								 
 								 default:									 
									 return "Next";
							} 
 					}
				}


				 ///<summary>No</summary>
				public static string GeneralUI_NO
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "No";
								 case "zh-HK":
									 return "No";
								  case "en-US":
									 return "No";
 								 
 								 default:									 
									 return "No";
							} 
 					}
				}


				 ///<summary>沒有可疑的篡改記錄！！！！</summary>
				public static string GeneralUI_NoDataRecruitment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有可疑的篡改记录！！！！";
								 case "zh-HK":
									 return "沒有可疑的篡改記錄！！！！";
								  case "en-US":
									 return "No data recruitment";
 								 
 								 default:									 
									 return "No data recruitment";
							} 
 					}
				}


				 ///<summary>沒有提供參數</summary>
				public static string GeneralUI_NoParms
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?有提供??";
								 case "zh-HK":
									 return "沒有提供參數";
								  case "en-US":
									 return "No parameters provided";
 								 
 								 default:									 
									 return "No parameters provided";
							} 
 					}
				}


				 ///<summary>無記錄</summary>
				public static string GeneralUI_NoRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无记录";
								 case "zh-HK":
									 return "無記錄";
								  case "en-US":
									 return "No Record";
 								 
 								 default:									 
									 return "No Record";
							} 
 					}
				}


				 ///<summary>沒有相關記錄</summary>
				public static string GeneralUI_NotExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有相关记录";
								 case "zh-HK":
									 return "沒有相關記錄";
								  case "en-US":
									 return "Not exist relate record";
 								 
 								 default:									 
									 return "Not exist relate record";
							} 
 					}
				}


				 ///<summary>沒有任何勾選</summary>
				public static string GeneralUI_NothingToCheck
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有任何勾选";
								 case "zh-HK":
									 return "沒有任何勾選";
								  case "en-US":
									 return "Nothing to check";
 								 
 								 default:									 
									 return "Nothing to check";
							} 
 					}
				}


				 ///<summary>OK</summary>
				public static string GeneralUI_OK
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "OK";
								 case "zh-HK":
									 return "OK";
								  case "en-US":
									 return "OK";
 								 
 								 default:									 
									 return "OK";
							} 
 					}
				}


				 ///<summary>選填</summary>
				public static string GeneralUI_Optional
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "选填";
								 case "zh-HK":
									 return "選填";
								  case "en-US":
									 return "Optional";
 								 
 								 default:									 
									 return "Optional";
							} 
 					}
				}


				 ///<summary>或</summary>
				public static string GeneralUI_OR
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "或";
								 case "zh-HK":
									 return "或";
								  case "en-US":
									 return "OR";
 								 
 								 default:									 
									 return "OR";
							} 
 					}
				}


				 ///<summary>排序</summary>
				public static string GeneralUI_OrderBy
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排序";
								 case "zh-HK":
									 return "排序";
								  case "en-US":
									 return "Order By";
 								 
 								 default:									 
									 return "Order By";
							} 
 					}
				}


				 ///<summary>按時間排序</summary>
				public static string GeneralUI_OrderByDatetime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "按时间排序";
								 case "zh-HK":
									 return "按時間排序";
								  case "en-US":
									 return "Order By Datetime";
 								 
 								 default:									 
									 return "Order By Datetime";
							} 
 					}
				}


				 ///<summary>按字母順序</summary>
				public static string GeneralUI_OrderByLetter
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "按字母顺序";
								 case "zh-HK":
									 return "按字母順序";
								  case "en-US":
									 return "Order By Letter";
 								 
 								 default:									 
									 return "Order By Letter";
							} 
 					}
				}


				 ///<summary>加班</summary>
				public static string GeneralUI_OverTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班";
								 case "zh-HK":
									 return "加班";
								  case "en-US":
									 return "OverTime";
 								 
 								 default:									 
									 return "OverTime";
							} 
 					}
				}


				 ///<summary>頁碼無或0</summary>
				public static string GeneralUI_PAGE_NO_ERR
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "页码无或0";
								 case "zh-HK":
									 return "頁碼無或0";
								  case "en-US":
									 return "PAGE NO ERR OR 0";
 								 
 								 default:									 
									 return "PAGE NO ERR OR 0";
							} 
 					}
				}


				 ///<summary>Password</summary>
				public static string GeneralUI_Password
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Password";
								 case "zh-HK":
									 return "Password";
								  case "en-US":
									 return "Password";
 								 
 								 default:									 
									 return "Password";
							} 
 					}
				}


				 ///<summary>PhoneNumber</summary>
				public static string GeneralUI_PhoneNumber
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "PhoneNumber";
								 case "zh-HK":
									 return "PhoneNumber";
								  case "en-US":
									 return "PhoneNumber";
 								 
 								 default:									 
									 return "PhoneNumber";
							} 
 					}
				}


				 ///<summary>請選擇語言</summary>
				public static string GeneralUI_PleaseSelectLanguage
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请选择语言";
								 case "zh-HK":
									 return "請選擇語言";
								  case "en-US":
									 return "Please Select Language";
 								 
 								 default:									 
									 return "Please Select Language";
							} 
 					}
				}


				 ///<summary>請耐心等待......</summary>
				public static string GeneralUI_PleaseWaiting
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请耐心等待......";
								 case "zh-HK":
									 return "請耐心等待......";
								  case "en-US":
									 return "Please Waiting......";
 								 
 								 default:									 
									 return "Please Waiting......";
							} 
 					}
				}


				 ///<summary>按F11全屏</summary>
				public static string GeneralUI_PressF11ToFullScreen
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "按F11全屏";
								 case "zh-HK":
									 return "按F11全屏";
								  case "en-US":
									 return "Press F11 to FullScreen";
 								 
 								 default:									 
									 return "Press F11 to FullScreen";
							} 
 					}
				}


				 ///<summary>把NFC CARD 貼近感應區</summary>
				public static string GeneralUI_PutOnNFCSenseArea
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "把NFC CARD 贴近感应区";
								 case "zh-HK":
									 return "把NFC CARD 貼近感應區";
								  case "en-US":
									 return "Put the NFC CARD close on the sensing area";
 								 
 								 default:									 
									 return "Put the NFC CARD close on the sensing area";
							} 
 					}
				}


				 ///<summary>比率</summary>
				public static string GeneralUI_Ratio
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "比率";
								 case "zh-HK":
									 return "比率";
								  case "en-US":
									 return "Ratio";
 								 
 								 default:									 
									 return "Ratio";
							} 
 					}
				}


				 ///<summary>Register</summary>
				public static string GeneralUI_Register
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Register";
								 case "zh-HK":
									 return "Register";
								  case "en-US":
									 return "Register";
 								 
 								 default:									 
									 return "Register";
							} 
 					}
				}


				 ///<summary>注冊失敗</summary>
				public static string GeneralUI_RegisterFail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注册失败";
								 case "zh-HK":
									 return "注冊失敗";
								  case "en-US":
									 return "Register Fail";
 								 
 								 default:									 
									 return "Register Fail";
							} 
 					}
				}


				 ///<summary>備註</summary>
				public static string GeneralUI_Remarks
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "备注";
								 case "zh-HK":
									 return "備註";
								  case "en-US":
									 return "Remarks";
 								 
 								 default:									 
									 return "Remarks";
							} 
 					}
				}


				 ///<summary>存在重復輸入操作</summary>
				public static string GeneralUI_Repeated
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在重复输入操作";
								 case "zh-HK":
									 return "存在重復輸入操作";
								  case "en-US":
									 return "The Key Data Repeating Operation";
 								 
 								 default:									 
									 return "The Key Data Repeating Operation";
							} 
 					}
				}


				 ///<summary>必填</summary>
				public static string GeneralUI_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "必填";
								 case "zh-HK":
									 return "必填";
								  case "en-US":
									 return "Required";
 								 
 								 default:									 
									 return "Required";
							} 
 					}
				}


				 ///<summary>需要使用安卓App</summary>
				public static string GeneralUI_RequiredAnroidApp
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "需要使用安卓App";
								 case "zh-HK":
									 return "需要使用安卓App";
								  case "en-US":
									 return "Need to use Android App";
 								 
 								 default:									 
									 return "Need to use Android App";
							} 
 					}
				}


				 ///<summary>重置</summary>
				public static string GeneralUI_Reset
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "重置";
								 case "zh-HK":
									 return "重置";
								  case "en-US":
									 return "Reset";
 								 
 								 default:									 
									 return "Reset";
							} 
 					}
				}


				 ///<summary>返 回</summary>
				public static string GeneralUI_Return
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "返 回";
								 case "zh-HK":
									 return "返 回";
								  case "en-US":
									 return "Return";
 								 
 								 default:									 
									 return "Return";
							} 
 					}
				}


				 ///<summary>返回錯誤代碼</summary>
				public static string GeneralUI_ReturnErrorCode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "返回错误代码";
								 case "zh-HK":
									 return "返回錯誤代碼";
								  case "en-US":
									 return "ReturnErrorCode";
 								 
 								 default:									 
									 return "ReturnErrorCode";
							} 
 					}
				}


				 ///<summary>返回操作結果</summary>
				public static string GeneralUI_ReturnResult
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "返回操作结果";
								 case "zh-HK":
									 return "返回操作結果";
								  case "en-US":
									 return "Return Operation Result";
 								 
 								 default:									 
									 return "Return Operation Result";
							} 
 					}
				}


				 ///<summary>返回列表</summary>
				public static string GeneralUI_ReturnToList
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "返回列表";
								 case "zh-HK":
									 return "返回列表";
								  case "en-US":
									 return "Return to list";
 								 
 								 default:									 
									 return "Return to list";
							} 
 					}
				}


				 ///<summary>保存</summary>
				public static string GeneralUI_SaveChanges
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "保存";
								 case "zh-HK":
									 return "保存";
								  case "en-US":
									 return "Save Changes";
 								 
 								 default:									 
									 return "Save Changes";
							} 
 					}
				}


				 ///<summary>選 擇</summary>
				public static string GeneralUI_Select
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "选 择";
								 case "zh-HK":
									 return "選 擇";
								  case "en-US":
									 return "Select";
 								 
 								 default:									 
									 return "Select";
							} 
 					}
				}


				 ///<summary>全選</summary>
				public static string GeneralUI_SelectALL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "全选";
								 case "zh-HK":
									 return "全選";
								  case "en-US":
									 return "SelectALL";
 								 
 								 default:									 
									 return "SelectALL";
							} 
 					}
				}


				 ///<summary>發生服務器內容錯誤！</summary>
				public static string GeneralUI_ServerError
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "发生服务器内容错误！";
								 case "zh-HK":
									 return "發生服務器內容錯誤！";
								  case "en-US":
									 return "Occur server internal error";
 								 
 								 default:									 
									 return "Occur server internal error";
							} 
 					}
				}


				 ///<summary>登出</summary>
				public static string GeneralUI_SignOut
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登出";
								 case "zh-HK":
									 return "登出";
								  case "en-US":
									 return "SignOut";
 								 
 								 default:									 
									 return "SignOut";
							} 
 					}
				}


				 ///<summary>Skip</summary>
				public static string GeneralUI_Skip
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Skip";
								 case "zh-HK":
									 return "Skip";
								  case "en-US":
									 return "Skip";
 								 
 								 default:									 
									 return "Skip";
							} 
 					}
				}


				 ///<summary>Submit</summary>
				public static string GeneralUI_Submit
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Submit";
								 case "zh-HK":
									 return "Submit";
								  case "en-US":
									 return "Submit";
 								 
 								 default:									 
									 return "Submit";
							} 
 					}
				}


				 ///<summary>成功</summary>
				public static string GeneralUI_SUCC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "成功";
								 case "zh-HK":
									 return "成功";
								  case "en-US":
									 return "SUCCESS";
 								 
 								 default:									 
									 return "SUCCESS";
							} 
 					}
				}


				 ///<summary>成 功</summary>
				public static string GeneralUI_Success
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "成 功";
								 case "zh-HK":
									 return "成 功";
								  case "en-US":
									 return "Success";
 								 
 								 default:									 
									 return "Success";
							} 
 					}
				}


				 ///<summary>系統語言</summary>
				public static string GeneralUI_SysemLanguage
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统语言";
								 case "zh-HK":
									 return "系統語言";
								  case "en-US":
									 return "Sysem Language";
 								 
 								 default:									 
									 return "Sysem Language";
							} 
 					}
				}


				 ///<summary>系 統</summary>
				public static string GeneralUI_System
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系 统";
								 case "zh-HK":
									 return "系 統";
								  case "en-US":
									 return "System";
 								 
 								 default:									 
									 return "System";
							} 
 					}
				}


				 ///<summary>感謝您確認您的電子郵件。</summary>
				public static string GeneralUI_ThankConfirmingEmail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "感谢您确认您的电子邮件。";
								 case "zh-HK":
									 return "感謝您確認您的電子郵件。";
								  case "en-US":
									 return "Thank you for confirming your email.";
 								 
 								 default:									 
									 return "Thank you for confirming your email.";
							} 
 					}
				}


				 ///<summary>考慮一下先吧！</summary>
				public static string GeneralUI_ThinkAboutIt
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考虑一下先吧！";
								 case "zh-HK":
									 return "考慮一下先吧！";
								  case "en-US":
									 return "Think about it!";
 								 
 								 default:									 
									 return "Think about it!";
							} 
 					}
				}


				 ///<summary>HH:mm</summary>
				public static string GeneralUI_TimeFormate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "HH:mm";
								 case "zh-HK":
									 return "HH:mm";
								  case "en-US":
									 return "HH:mm";
 								 
 								 default:									 
									 return "HH:mm";
							} 
 					}
				}


				 ///<summary>次</summary>
				public static string GeneralUI_Times
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "次";
								 case "zh-HK":
									 return "次";
								  case "en-US":
									 return "Times";
 								 
 								 default:									 
									 return "Times";
							} 
 					}
				}


				 ///<summary>注意：時長格式06.01:05:53天：表示6天.1小時5分鐘53秒</summary>
				public static string GeneralUI_TimeSpanFormat_Note
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注意：时长格式06.01:05:53天：表示6天.1小时5分钟53秒";
								 case "zh-HK":
									 return "注意：時長格式06.01:05:53天：表示6天.1小時5分鐘53秒";
								  case "en-US":
									 return "NOTE: TimeSpanFormat 06.01:05:53 days, It mean 6 days 1 hours 5mins 53 seconds";
 								 
 								 default:									 
									 return "NOTE: TimeSpanFormat 06.01:05:53 days, It mean 6 days 1 hours 5mins 53 seconds";
							} 
 					}
				}


				 ///<summary>總共</summary>
				public static string GeneralUI_Total
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "总共";
								 case "zh-HK":
									 return "總共";
								  case "en-US":
									 return "Total";
 								 
 								 default:									 
									 return "Total";
							} 
 					}
				}


				 ///<summary>是</summary>
				public static string GeneralUI_TRUE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "是";
								 case "zh-HK":
									 return "是";
								  case "en-US":
									 return "TRUE";
 								 
 								 default:									 
									 return "TRUE";
							} 
 					}
				}


				 ///<summary>非授權</summary>
				public static string GeneralUI_UNAUTHORIED
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "非授权";
								 case "zh-HK":
									 return "非授權";
								  case "en-US":
									 return "UNAUTHORIED";
 								 
 								 default:									 
									 return "UNAUTHORIED";
							} 
 					}
				}


				 ///<summary>更 新</summary>
				public static string GeneralUI_Update
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "更 新";
								 case "zh-HK":
									 return "更 新";
								  case "en-US":
									 return "Update";
 								 
 								 default:									 
									 return "Update";
							} 
 					}
				}


				 ///<summary>上存</summary>
				public static string GeneralUI_Upload
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上存";
								 case "zh-HK":
									 return "上存";
								  case "en-US":
									 return "Upload";
 								 
 								 default:									 
									 return "Upload";
							} 
 					}
				}


				 ///<summary>UserName</summary>
				public static string GeneralUI_UserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "UserName";
								 case "zh-HK":
									 return "UserName";
								  case "en-US":
									 return "UserName";
 								 
 								 default:									 
									 return "UserName";
							} 
 					}
				}


				 ///<summary>有效</summary>
				public static string GeneralUI_Valid
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "有效";
								 case "zh-HK":
									 return "有效";
								  case "en-US":
									 return "Is Valid";
 								 
 								 default:									 
									 return "Is Valid";
							} 
 					}
				}


				 ///<summary>等候批準</summary>
				public static string GeneralUI_WaitingForApproval
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "等候批准";
								 case "zh-HK":
									 return "等候批準";
								  case "en-US":
									 return "Waiting for approval";
 								 
 								 default:									 
									 return "Waiting for approval";
							} 
 					}
				}


				 ///<summary>警告</summary>
				public static string GeneralUI_Warning
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "警告";
								 case "zh-HK":
									 return "警告";
								  case "en-US":
									 return "Warning";
 								 
 								 default:									 
									 return "Warning";
							} 
 					}
				}


				 ///<summary>每周</summary>
				public static string GeneralUI_WEEKLY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每周";
								 case "zh-HK":
									 return "每周";
								  case "en-US":
									 return "WEEKLY";
 								 
 								 default:									 
									 return "WEEKLY";
							} 
 					}
				}


				 ///<summary>每年</summary>
				public static string GeneralUI_YEARLY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每年";
								 case "zh-HK":
									 return "每年";
								  case "en-US":
									 return "YEARLY";
 								 
 								 default:									 
									 return "YEARLY";
							} 
 					}
				}


				 ///<summary>Yes</summary>
				public static string GeneralUI_Yes
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Yes";
								 case "zh-HK":
									 return "Yes";
								  case "en-US":
									 return "Yes";
 								 
 								 default:									 
									 return "Yes";
							} 
 					}
				}


				 ///<summary>沒有登記注冊的設備</summary>
				public static string GetDeviceList_No_REGISTED_DEVICE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有登记注册的设备";
								 case "zh-HK":
									 return "沒有登記注冊的設備";
								  case "en-US":
									 return "No REGISTED DEVICE";
 								 
 								 default:									 
									 return "No REGISTED DEVICE";
							} 
 					}
				}


				 ///<summary>手機GPS定位</summary>
				public static string GPScreate_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手机GPS定位";
								 case "zh-HK":
									 return "手機GPS定位";
								  case "en-US":
									 return "GPS";
 								 
 								 default:									 
									 return "GPS";
							} 
 					}
				}


				 ///<summary>創建假期</summary>
				public static string Holiday_HolidayAddNew_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "创建假期";
								 case "zh-HK":
									 return "創建假期";
								  case "en-US":
									 return "Add new a holiday";
 								 
 								 default:									 
									 return "Add new a holiday";
							} 
 					}
				}


				 ///<summary>假期名稱</summary>
				public static string Holiday_HolidayCnName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期名称";
								 case "zh-HK":
									 return "假期名稱";
								  case "en-US":
									 return "Holiday Name";
 								 
 								 default:									 
									 return "Holiday Name";
							} 
 					}
				}


				 ///<summary>假期日期</summary>
				public static string Holiday_HolidayDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期日期";
								 case "zh-HK":
									 return "假期日期";
								  case "en-US":
									 return "Holiday Date";
 								 
 								 default:									 
									 return "Holiday Date";
							} 
 					}
				}


				 ///<summary>連續多日需要分別增加<br>(假期不一定日期范圍)</summary>
				public static string Holiday_HolidayDate_Readme
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "连续多日需要分别增加<br>(假期不一定日期范围)";
								 case "zh-HK":
									 return "連續多日需要分別增加<br>(假期不一定日期范圍)";
								  case "en-US":
									 return "If serveral days,need to add new separately for several times (the holiday is uncertainly in the date range)";
 								 
 								 default:									 
									 return "If serveral days,need to add new separately for several times (the holiday is uncertainly in the date range)";
							} 
 					}
				}


				 ///<summary>假期英文名稱</summary>
				public static string Holiday_HolidayEnName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期英文名称";
								 case "zh-HK":
									 return "假期英文名稱";
								  case "en-US":
									 return "Holiday Eng Name";
 								 
 								 default:									 
									 return "Holiday Eng Name";
							} 
 					}
				}


				 ///<summary>假期ID</summary>
				public static string Holiday_HolidayId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期ID";
								 case "zh-HK":
									 return "假期ID";
								  case "en-US":
									 return "Holiday ID";
 								 
 								 default:									 
									 return "Holiday ID";
							} 
 					}
				}


				 ///<summary>是否有薪</summary>
				public static string Holiday_HolidayPaidType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "是否有薪";
								 case "zh-HK":
									 return "是否有薪";
								  case "en-US":
									 return "With Salary";
 								 
 								 default:									 
									 return "With Salary";
							} 
 					}
				}


				 ///<summary>薪酬假期</summary>
				public static string Holiday_HolidayPaidTypeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "薪酬假期";
								 case "zh-HK":
									 return "薪酬假期";
								  case "en-US":
									 return "Leave Paid Type Name";
 								 
 								 default:									 
									 return "Leave Paid Type Name";
							} 
 					}
				}


				 ///<summary>是否整天假</summary>
				public static string Holiday_IsWholeDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "是否整天假";
								 case "zh-HK":
									 return "是否整天假";
								  case "en-US":
									 return "IS WHOLE DAY";
 								 
 								 default:									 
									 return "IS WHOLE DAY";
							} 
 					}
				}


				 ///<summary>不存在的假期定義</summary>
				public static string Holiday_NotExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "不存在的假期定义";
								 case "zh-HK":
									 return "不存在的假期定義";
								  case "en-US":
									 return "Not exist holiday record";
 								 
 								 default:									 
									 return "Not exist holiday record";
							} 
 					}
				}


				 ///<summary>薪酬計算率</summary>
				public static string Holiday_OnDutyPaidRatio
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "薪酬计算率";
								 case "zh-HK":
									 return "薪酬計算率";
								  case "en-US":
									 return "OnDuty PaidRatio";
 								 
 								 default:									 
									 return "OnDuty PaidRatio";
							} 
 					}
				}


				 ///<summary>公眾假期</summary>
				public static string Holiday_StatutoryHoliday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公众假期";
								 case "zh-HK":
									 return "公眾假期";
								  case "en-US":
									 return "Statutory Holiday";
 								 
 								 default:									 
									 return "Statutory Holiday";
							} 
 					}
				}


				 ///<summary>已經存在當前日期的定義</summary>
				public static string HolidayAddNew_ExistTheSameHolidayDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已经存在当前日期的定义";
								 case "zh-HK":
									 return "已經存在當前日期的定義";
								  case "en-US":
									 return "Exist the same holiday date";
 								 
 								 default:									 
									 return "Exist the same holiday date";
							} 
 					}
				}


				 ///<summary>請選擇是否整天假</summary>
				public static string HolidayAddNew_HolidayIsWholeDayType_Select
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请选择是否整天假";
								 case "zh-HK":
									 return "請選擇是否整天假";
								  case "en-US":
									 return "Please Select IsWholeDayType";
 								 
 								 default:									 
									 return "Please Select IsWholeDayType";
							} 
 					}
				}


				 ///<summary>僅下午</summary>
				public static string HolidayIsWholeDayType_OnlyAfterNoon
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "仅下午";
								 case "zh-HK":
									 return "僅下午";
								  case "en-US":
									 return "Only AfterNoon";
 								 
 								 default:									 
									 return "Only AfterNoon";
							} 
 					}
				}


				 ///<summary>僅上午</summary>
				public static string HolidayIsWholeDayType_OnlyMorning
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "仅上午";
								 case "zh-HK":
									 return "僅上午";
								  case "en-US":
									 return "Only Morning";
 								 
 								 default:									 
									 return "Only Morning";
							} 
 					}
				}


				 ///<summary>整天</summary>
				public static string HolidayIsWholeDayType_WholeDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "整天";
								 case "zh-HK":
									 return "整天";
								  case "en-US":
									 return "Whole Day";
 								 
 								 default:									 
									 return "Whole Day";
							} 
 					}
				}


				 ///<summary>好吧！再考慮一下吧！</summary>
				public static string HolidayList_ComfirmNoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "好吧！再考虑一下吧！";
								 case "zh-HK":
									 return "好吧！再考慮一下吧！";
								  case "en-US":
									 return "OK! Think about it again!";
 								 
 								 default:									 
									 return "OK! Think about it again!";
							} 
 					}
				}


				 ///<summary>確認刪除當前假期嗎？</summary>
				public static string HolidayList_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认删除当前假期吗？";
								 case "zh-HK":
									 return "確認刪除當前假期嗎？";
								  case "en-US":
									 return "Comfirm delete this Holiday?";
 								 
 								 default:									 
									 return "Comfirm delete this Holiday?";
							} 
 					}
				}


				 ///<summary>刪除的30天內假期會影響排班計算邏輯</summary>
				public static string HolidayList_ComfirmTips2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "删除的30天内假期会影响排班计算逻辑";
								 case "zh-HK":
									 return "刪除的30天內假期會影響排班計算邏輯";
								  case "en-US":
									 return "If deleted , It will make a conflict on schedule and attendance calculate logic！";
 								 
 								 default:									 
									 return "If deleted , It will make a conflict on schedule and attendance calculate logic！";
							} 
 					}
				}


				 ///<summary>選擇假期范圍</summary>
				public static string HolidayList_HolidayDateRange
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "选择假期范围";
								 case "zh-HK":
									 return "選擇假期范圍";
								  case "en-US":
									 return "Select holiday date range";
 								 
 								 default:									 
									 return "Select holiday date range";
							} 
 					}
				}


				 ///<summary>無薪假期</summary>
				public static string HolidayList_NoSalary
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无薪假期";
								 case "zh-HK":
									 return "無薪假期";
								  case "en-US":
									 return "No Salary";
 								 
 								 default:									 
									 return "No Salary";
							} 
 					}
				}


				 ///<summary>假期列表</summary>
				public static string HolidayList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期列表";
								 case "zh-HK":
									 return "假期列表";
								  case "en-US":
									 return "Holiday List";
 								 
 								 default:									 
									 return "Holiday List";
							} 
 					}
				}


				 ///<summary>有薪假期</summary>
				public static string HolidayList_WithSalary
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "有薪假期";
								 case "zh-HK":
									 return "有薪假期";
								  case "en-US":
									 return "With Salary";
 								 
 								 default:									 
									 return "With Salary";
							} 
 					}
				}


				 ///<summary>有薪公共假期</summary>
				public static string HolidayPaidType_PAID_HOLIDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "有薪公共假期";
								 case "zh-HK":
									 return "有薪公共假期";
								  case "en-US":
									 return "Paid holiday";
 								 
 								 default:									 
									 return "Paid holiday";
							} 
 					}
				}


				 ///<summary>選擇有薪假期情況下，不能設置薪酬計算率為0</summary>
				public static string HolidayPaidType_PAIDOnDutyPaidRatioTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "选择有薪假期情况下，不能设置薪酬计算率为0";
								 case "zh-HK":
									 return "選擇有薪假期情況下，不能設置薪酬計算率為0";
								  case "en-US":
									 return "If you choose Holiday paid , you cannot set 0 of OnDutyPaidRatio";
 								 
 								 default:									 
									 return "If you choose Holiday paid , you cannot set 0 of OnDutyPaidRatio";
							} 
 					}
				}


				 ///<summary>無薪公共假期</summary>
				public static string HolidayPaidType_UNPAID_HOLIDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无薪公共假期";
								 case "zh-HK":
									 return "無薪公共假期";
								  case "en-US":
									 return "UNPAI HOLIDAY";
 								 
 								 default:									 
									 return "UNPAI HOLIDAY";
							} 
 					}
				}


				 ///<summary>選擇無薪假期前提必須設置薪酬計算率為0%</summary>
				public static string HolidayPaidType_UNPAIDAndOnDutyPaidRatioTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "选择无薪假期前提必须设置薪酬计算率为0%";
								 case "zh-HK":
									 return "選擇無薪假期前提必須設置薪酬計算率為0%";
								  case "en-US":
									 return "If UNPAID seleted，please select OnDutyPaidRatio = 0%";
 								 
 								 default:									 
									 return "If UNPAID seleted，please select OnDutyPaidRatio = 0%";
							} 
 					}
				}


				 ///<summary>第三方服務2</summary>
				public static string IN00001_LeftMenu_EmployeeDetails_The3Rd_MenuTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方服务2";
								 case "zh-HK":
									 return "第三方服務2";
								  case "en-US":
									 return "The 3rd Party Service 2";
 								 
 								 default:									 
									 return "The 3rd Party Service 2";
							} 
 					}
				}


				 ///<summary>第三方服務1</summary>
				public static string IN00001_LeftMenu_EmployeeList_The3Rd_MenuTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方服务1000";
								 case "zh-HK":
									 return "第三方服務1";
								  case "en-US":
									 return "The 3rd Party Service 1";
 								 
 								 default:									 
									 return "The 3rd Party Service 1";
							} 
 					}
				}


				 ///<summary>多語言管理 IN60006</summary>
				public static string IN60006_Language_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "多语言管理 IN60006";
								 case "zh-HK":
									 return "多語言管理 IN60006";
								  case "en-US":
									 return "Multilingual management-IN60006";
 								 
 								 default:									 
									 return "Multilingual management-IN60006";
							} 
 					}
				}


				 ///<summary>Industry Name</summary>
				public static string Industry_EnIndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Industry Name";
								 case "zh-HK":
									 return "Industry Name";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>行业</summary>
				public static string Industry_Industry
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业";
								 case "zh-HK":
									 return "行业";
								  case "en-US":
									 return "Industry";
 								 
 								 default:									 
									 return "Industry";
							} 
 					}
				}


				 ///<summary>Industry Id</summary>
				public static string Industry_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Industry Id";
								 case "zh-HK":
									 return "Industry Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>Industry Name</summary>
				public static string Industry_IndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Industry Name";
								 case "zh-HK":
									 return "Industry Name";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>行業ID不存在</summary>
				public static string Industry_NotExistIndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业ID不存在";
								 case "zh-HK":
									 return "行業ID不存在";
								  case "en-US":
									 return "Not Exist IndustryId";
 								 
 								 default:									 
									 return "Not Exist IndustryId";
							} 
 					}
				}


				 ///<summary>Parents Id</summary>
				public static string Industry_ParentsIndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Parents Id";
								 case "zh-HK":
									 return "Parents Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>請選擇行業名稱</summary>
				public static string Industry_PlsSelectIndustry
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请选择行业名称";
								 case "zh-HK":
									 return "請選擇行業名稱";
								  case "en-US":
									 return "Please select industry";
 								 
 								 default:									 
									 return "Please select industry";
							} 
 					}
				}


				 ///<summary>請選擇行業名稱</summary>
				public static string IndustryDetails_NeedIndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请选择行业名称";
								 case "zh-HK":
									 return "請選擇行業名稱";
								  case "en-US":
									 return "Please Industry Name";
 								 
 								 default:									 
									 return "Please Industry Name";
							} 
 					}
				}


				 ///<summary>行業ID集合沒有同步成功</summary>
				public static string IndustryEditDetails_IndustryIdArrStatus
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业ID集合没有同步成功";
								 case "zh-HK":
									 return "行業ID集合沒有同步成功";
								  case "en-US":
									 return "IndustryId array Synchronize fail";
 								 
 								 default:									 
									 return "IndustryId array Synchronize fail";
							} 
 					}
				}


				 ///<summary>工種名稱2</summary>
				public static string Job_EnJobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种名称2";
								 case "zh-HK":
									 return "工種名稱2";
								  case "en-US":
									 return "JobName2";
 								 
 								 default:									 
									 return "JobName2";
							} 
 					}
				}


				 ///<summary>Industry Id</summary>
				public static string Job_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Industry Id";
								 case "zh-HK":
									 return "Industry Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>行業</summary>
				public static string Job_IndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业";
								 case "zh-HK":
									 return "行業";
								  case "en-US":
									 return "Industry";
 								 
 								 default:									 
									 return "Industry";
							} 
 					}
				}


				 ///<summary>新增工種</summary>
				public static string Job_JobAddNew_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新增工种";
								 case "zh-HK":
									 return "新增工種";
								  case "en-US":
									 return "Add a new job";
 								 
 								 default:									 
									 return "Add a new job";
							} 
 					}
				}


				 ///<summary>工種Id</summary>
				public static string Job_JobId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种Id";
								 case "zh-HK":
									 return "工種Id";
								  case "en-US":
									 return "Job Id";
 								 
 								 default:									 
									 return "Job Id";
							} 
 					}
				}


				 ///<summary>工種名稱</summary>
				public static string Job_JobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种名称";
								 case "zh-HK":
									 return "工種名稱";
								  case "en-US":
									 return "JobName";
 								 
 								 default:									 
									 return "JobName";
							} 
 					}
				}


				 ///<summary>不存在工種記錄</summary>
				public static string Job_NotExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "不存在工种记录";
								 case "zh-HK":
									 return "不存在工種記錄";
								  case "en-US":
									 return "Job Name is not exist record";
 								 
 								 default:									 
									 return "Job Name is not exist record";
							} 
 					}
				}


				 ///<summary>The 3rd JobId</summary>
				public static string Job_The3rdJobId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "The 3rd JobId";
								 case "zh-HK":
									 return "The 3rd JobId";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>存在相同的工種名稱</summary>
				public static string JobAddNew_ExistTheSameJobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在相同的工种名称";
								 case "zh-HK":
									 return "存在相同的工種名稱";
								  case "en-US":
									 return "The same job name is exist!";
 								 
 								 default:									 
									 return "The same job name is exist!";
							} 
 					}
				}


				 ///<summary>請輸入工種名稱</summary>
				public static string JobDetails_NeedJobName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入工种名称";
								 case "zh-HK":
									 return "請輸入工種名稱";
								  case "en-US":
									 return "Please input a new job Name";
 								 
 								 default:									 
									 return "Please input a new job Name";
							} 
 					}
				}


				 ///<summary>好吧！再考慮一下吧！</summary>
				public static string JobList_ComfirmNoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "好吧！再考虑一下吧！";
								 case "zh-HK":
									 return "好吧！再考慮一下吧！";
								  case "en-US":
									 return "OK! Think about it again!";
 								 
 								 default:									 
									 return "OK! Think about it again!";
							} 
 					}
				}


				 ///<summary>確認刪除當前部門嗎？</summary>
				public static string JobList_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认删除当前部门吗？";
								 case "zh-HK":
									 return "確認刪除當前部門嗎？";
								  case "en-US":
									 return "Comfirm delete this job?";
 								 
 								 default:									 
									 return "Comfirm delete this job?";
							} 
 					}
				}


				 ///<summary>編輯工種</summary>
				public static string JobList_EditJobDetails_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "编辑工种";
								 case "zh-HK":
									 return "編輯工種";
								  case "en-US":
									 return "Job Details";
 								 
 								 default:									 
									 return "Job Details";
							} 
 					}
				}


				 ///<summary>工種列表</summary>
				public static string JobList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工种列表";
								 case "zh-HK":
									 return "工種列表";
								  case "en-US":
									 return "Job List";
 								 
 								 default:									 
									 return "Job List";
							} 
 					}
				}


				 ///<summary>英文</summary>
				public static string Language_en_US
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "英文";
								 case "zh-HK":
									 return "英文";
								  case "en-US":
									 return "English";
 								 
 								 default:									 
									 return "English";
							} 
 					}
				}


				 ///<summary>English</summary>
				public static string Language_English
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "English";
								 case "zh-HK":
									 return "English";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>Industry Id</summary>
				public static string Language_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Industry Id";
								 case "zh-HK":
									 return "Industry Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>行業</summary>
				public static string Language_IndustryIdArr
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业";
								 case "zh-HK":
									 return "行業";
								  case "en-US":
									 return "Industry";
 								 
 								 default:									 
									 return "Industry";
							} 
 					}
				}


				 ///<summary>應用行業術語</summary>
				public static string Language_IsAppliedIndustry
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "應用行業術語";
								 case "zh-HK":
									 return "應用行業術語";
								  case "en-US":
									 return "應用行業術語";
 								 
 								 default:									 
									 return "應用行業術語";
							} 
 					}
				}


				 ///<summary>KeyName</summary>
				public static string Language_KeyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "KeyName";
								 case "zh-HK":
									 return "KeyName";
								  case "en-US":
									 return "KeyName";
 								 
 								 default:									 
									 return "KeyName";
							} 
 					}
				}


				 ///<summary>Key Type</summary>
				public static string Language_KeyType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Key Type";
								 case "zh-HK":
									 return "Key Type";
								  case "en-US":
									 return "Key Type";
 								 
 								 default:									 
									 return "Key Type";
							} 
 					}
				}


				 ///<summary>多語言</summary>
				public static string Language_MultiLingual
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "多语言";
								 case "zh-HK":
									 return "多語言";
								  case "en-US":
									 return "Multi Lingual";
 								 
 								 default:									 
									 return "Multi Lingual";
							} 
 					}
				}


				 ///<summary>KeyName不存在</summary>
				public static string Language_NotExistKeyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "KeyName不存在";
								 case "zh-HK":
									 return "KeyName不存在";
								  case "en-US":
									 return "Not Exist KeyName";
 								 
 								 default:									 
									 return "Not Exist KeyName";
							} 
 					}
				}


				 ///<summary>Remark</summary>
				public static string Language_Remark
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Remark";
								 case "zh-HK":
									 return "Remark";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>Simplify</summary>
				public static string Language_Simplify
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Simplify";
								 case "zh-HK":
									 return "Simplify";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>多語言管理</summary>
				public static string Language_Title
				{
					get
					{


						if ("IN60006_Language_Title".Contains(LangUtilities.IndustryCode))
						{
 							return Lang.IN60006_Language_Title; 
						}
						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "多语言管理";
								 case "zh-HK":
									 return "多語言管理";
								  case "en-US":
									 return "Multilingual management";
 								 
 								 default:									 
									 return "Multilingual management";
							} 
 					}
				}


				 ///<summary>Traditional</summary>
				public static string Language_Traditional
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Traditional";
								 case "zh-HK":
									 return "Traditional";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>屬於行業KeyName，不能定義，違反規則。</summary>
				public static string Language_ViolateRule
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "属於行业KeyName，不能定义，违反规则。";
								 case "zh-HK":
									 return "屬於行業KeyName，不能定義，違反規則。";
								  case "en-US":
									 return "It is belong to industry KeyName, can not be definited to violate rule!";
 								 
 								 default:									 
									 return "It is belong to industry KeyName, can not be definited to violate rule!";
							} 
 					}
				}


				 ///<summary>简体</summary>
				public static string Language_zh_CN
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "简体";
								 case "zh-HK":
									 return "简体";
								  case "en-US":
									 return "Simplify Chinese";
 								 
 								 default:									 
									 return "Simplify Chinese";
							} 
 					}
				}


				 ///<summary>繁体</summary>
				public static string Language_zh_HK
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "繁体";
								 case "zh-HK":
									 return "繁体";
								  case "en-US":
									 return "Traditional Chinese";
 								 
 								 default:									 
									 return "Traditional Chinese";
							} 
 					}
				}


				 ///<summary>考勤编号（EployeeId）</summary>
				public static string Leave_EmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤编号（EployeeId）";
								 case "zh-HK":
									 return "考勤编号（EployeeId）";
								  case "en-US":
									 return "Attendance Id (EployeeId)";
 								 
 								 default:									 
									 return "Attendance Id (EployeeId)";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string Leave_EmployeeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Name";
 								 
 								 default:									 
									 return "Name";
							} 
 					}
				}


				 ///<summary>審批</summary>
				public static string Leave_IsApproved
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "審批";
								 case "zh-HK":
									 return "審批";
								  case "en-US":
									 return "IsApproved";
 								 
 								 default:									 
									 return "IsApproved";
							} 
 					}
				}


				 ///<summary>請假日期時間范圍</summary>
				public static string Leave_LeaveDateTimeRange
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假日期时间范围";
								 case "zh-HK":
									 return "請假日期時間范圍";
								  case "en-US":
									 return "Leave DateTime Range";
 								 
 								 default:									 
									 return "Leave DateTime Range";
							} 
 					}
				}


				 ///<summary>如果請假日期范圍不是連續的，請分開多次提交申請！</summary>
				public static string Leave_LeaveDateTimeRange_Tips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "如果请假日期范围不是连续的，请分开多次提交申请！";
								 case "zh-HK":
									 return "如果請假日期范圍不是連續的，請分開多次提交申請！";
								  case "en-US":
									 return "If the leave DateTime range is not constantly,please apply saparately.";
 								 
 								 default:									 
									 return "If the leave DateTime range is not constantly,please apply saparately.";
							} 
 					}
				}


				 ///<summary>請務必填入工作上班時間和下班時間為準。</summary>
				public static string Leave_LeaveDateTimeRange_Tips2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请务必填入工作上班时间和下班时间为准。";
								 case "zh-HK":
									 return "請務必填入工作上班時間和下班時間為準。";
								  case "en-US":
									 return "It is necessary to fill with the  work-on time and work-off time.";
 								 
 								 default:									 
									 return "It is necessary to fill with the  work-on time and work-off time.";
							} 
 					}
				}


				 ///<summary>結束日</summary>
				public static string Leave_LeaveEndDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "结束日";
								 case "zh-HK":
									 return "結束日";
								  case "en-US":
									 return "End Date";
 								 
 								 default:									 
									 return "End Date";
							} 
 					}
				}


				 ///<summary>Leave Id</summary>
				public static string Leave_LeaveId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Leave Id";
								 case "zh-HK":
									 return "Leave Id";
								  case "en-US":
									 return "Leave Id";
 								 
 								 default:									 
									 return "Leave Id";
							} 
 					}
				}


				 ///<summary>是否有薪</summary>
				public static string Leave_LeavePaidType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "是否有薪";
								 case "zh-HK":
									 return "是否有薪";
								  case "en-US":
									 return "With Salary";
 								 
 								 default:									 
									 return "With Salary";
							} 
 					}
				}


				 ///<summary>開始日</summary>
				public static string Leave_LeaveStartDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "开始日";
								 case "zh-HK":
									 return "開始日";
								  case "en-US":
									 return "StartDate";
 								 
 								 default:									 
									 return "StartDate";
							} 
 					}
				}


				 ///<summary>請假類別</summary>
				public static string Leave_LeaveType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假类别";
								 case "zh-HK":
									 return "請假類別";
								  case "en-US":
									 return "LeaveType";
 								 
 								 default:									 
									 return "LeaveType";
							} 
 					}
				}


				 ///<summary>請假類型</summary>
				public static string Leave_LeaveTypeName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假类型";
								 case "zh-HK":
									 return "請假類型";
								  case "en-US":
									 return "Leave Type";
 								 
 								 default:									 
									 return "Leave Type";
							} 
 					}
				}


				 ///<summary>理由</summary>
				public static string Leave_Reason
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "理由";
								 case "zh-HK":
									 return "理由";
								  case "en-US":
									 return "Reason";
 								 
 								 default:									 
									 return "Reason";
							} 
 					}
				}


				 ///<summary>當前的請假申請不存在記錄</summary>
				public static string Leave_ThisLeaveIdIsNotExist
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当前的请假申请不存在记录";
								 case "zh-HK":
									 return "當前的請假申請不存在記錄";
								  case "en-US":
									 return "This Leave Is Not Exist";
 								 
 								 default:									 
									 return "This Leave Is Not Exist";
							} 
 					}
				}


				 ///<summary>請假天數</summary>
				public static string Leave_TotalDays
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假天数";
								 case "zh-HK":
									 return "請假天數";
								  case "en-US":
									 return "TotalDays";
 								 
 								 default:									 
									 return "TotalDays";
							} 
 					}
				}


				 ///<summary>審批備注</summary>
				public static string LeaveListApprovedView_LeaveApproved_ApprovedRemark
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "审批备注";
								 case "zh-HK":
									 return "審批備注";
								  case "en-US":
									 return "Approved Remark";
 								 
 								 default:									 
									 return "Approved Remark";
							} 
 					}
				}


				 ///<summary>當前沒有請假申請</summary>
				public static string LeaveListPane_NoLeaveApplication
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当前没有请假申请";
								 case "zh-HK":
									 return "當前沒有請假申請";
								  case "en-US":
									 return "No leave application";
 								 
 								 default:									 
									 return "No leave application";
							} 
 					}
				}


				 ///<summary>请假快速審批</summary>
				public static string LeaveListPane_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假快速審批";
								 case "zh-HK":
									 return "请假快速審批";
								  case "en-US":
									 return "Leave Fast Approval";
 								 
 								 default:									 
									 return "Leave Fast Approval";
							} 
 					}
				}


				 ///<summary>有薪假期</summary>
				public static string LeavePaidType_PAID_LEAVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "有薪假期";
								 case "zh-HK":
									 return "有薪假期";
								  case "en-US":
									 return "Paid Leave";
 								 
 								 default:									 
									 return "Paid Leave";
							} 
 					}
				}


				 ///<summary>無薪假期</summary>
				public static string LeavePaidType_UNPAID_LEAVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无薪假期";
								 case "zh-HK":
									 return "無薪假期";
								  case "en-US":
									 return "unpaid Leave";
 								 
 								 default:									 
									 return "unpaid Leave";
							} 
 					}
				}


				 ///<summary>年假</summary>
				public static string LeaveType_ANNUAL_LEAVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "年假";
								 case "zh-HK":
									 return "年假";
								  case "en-US":
									 return "ANNUAL_LEAVE";
 								 
 								 default:									 
									 return "ANNUAL_LEAVE";
							} 
 					}
				}


				 ///<summary>一般假期</summary>
				public static string LeaveType_GENERAL_LEAVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "一般假期";
								 case "zh-HK":
									 return "一般假期";
								  case "en-US":
									 return "GENERAL LEAVE";
 								 
 								 default:									 
									 return "GENERAL LEAVE";
							} 
 					}
				}


				 ///<summary>病假</summary>
				public static string LeaveType_SICK_LEAVE
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "病假";
								 case "zh-HK":
									 return "病假";
								  case "en-US":
									 return "SICK LEAVE";
 								 
 								 default:									 
									 return "SICK LEAVE";
							} 
 					}
				}


				 ///<summary>公眾假期</summary>
				public static string LeaveType_STATUTORY_HOLIDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公众假期";
								 case "zh-HK":
									 return "公眾假期";
								  case "en-US":
									 return "STATUTORY HOLIDAY";
 								 
 								 default:									 
									 return "STATUTORY HOLIDAY";
							} 
 					}
				}


				 ///<summary>考勤編號必須的</summary>
				public static string LeaveView_EmployeeId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤编号必须的";
								 case "zh-HK":
									 return "考勤編號必須的";
								  case "en-US":
									 return "Attendance ID Required";
 								 
 								 default:									 
									 return "Attendance ID Required";
							} 
 					}
				}


				 ///<summary>輸入正確的員工編號（考勤編號）</summary>
				public static string LeaveView_EmployeeId_Tips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "输入正确的员工编号（考勤编号）";
								 case "zh-HK":
									 return "輸入正確的員工編號（考勤編號）";
								  case "en-US":
									 return "Please input the correct attendance Id";
 								 
 								 default:									 
									 return "Please input the correct attendance Id";
							} 
 					}
				}


				 ///<summary>請假日期時間范圍是必須的</summary>
				public static string LeaveView_LeaveDateTimeRange_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假日期时间范围是必须的";
								 case "zh-HK":
									 return "請假日期時間范圍是必須的";
								  case "en-US":
									 return "Leave DateTime Range Required";
 								 
 								 default:									 
									 return "Leave DateTime Range Required";
							} 
 					}
				}


				 ///<summary>請假結束時間必須的</summary>
				public static string LeaveView_LeaveEndDate_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假结束时间必须的";
								 case "zh-HK":
									 return "請假結束時間必須的";
								  case "en-US":
									 return "Leave End Date Time Required";
 								 
 								 default:									 
									 return "Leave End Date Time Required";
							} 
 					}
				}


				 ///<summary>是否有薪假是必須的</summary>
				public static string LeaveView_LeavePaidType_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "是否有薪假是必须的";
								 case "zh-HK":
									 return "是否有薪假是必須的";
								  case "en-US":
									 return "Leave PaidType is required";
 								 
 								 default:									 
									 return "Leave PaidType is required";
							} 
 					}
				}


				 ///<summary>請假類別必須的</summary>
				public static string LeaveView_LeaveType_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假类别必须的";
								 case "zh-HK":
									 return "請假類別必須的";
								  case "en-US":
									 return "LeaveType Required";
 								 
 								 default:									 
									 return "LeaveType Required";
							} 
 					}
				}


				 ///<summary>請填寫請假理由</summary>
				public static string LeaveView_Reason_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请填写请假理由";
								 case "zh-HK":
									 return "請填寫請假理由";
								  case "en-US":
									 return "The reason is Required";
 								 
 								 default:									 
									 return "The reason is Required";
							} 
 					}
				}


				 ///<summary>考勤報表</summary>
				public static string LeftMenu_AttendanceReports
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤报表";
								 case "zh-HK":
									 return "考勤報表";
								  case "en-US":
									 return "Attendance Reports";
 								 
 								 default:									 
									 return "Attendance Reports";
							} 
 					}
				}


				 ///<summary>第三方服務2</summary>
				public static string LeftMenu_EmployeeDetails_The3Rd_MenuTitle
				{
					get
					{


						if ("IN00001_LeftMenu_EmployeeDetails_The3Rd_MenuTitle".Contains(LangUtilities.IndustryCode))
						{
 							return Lang.IN00001_LeftMenu_EmployeeDetails_The3Rd_MenuTitle; 
						}
						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方服务2";
								 case "zh-HK":
									 return "第三方服務2";
								  case "en-US":
									 return "The 3rd Party Service 3";
 								 
 								 default:									 
									 return "The 3rd Party Service 3";
							} 
 					}
				}


				 ///<summary>雇員資料創建</summary>
				public static string LeftMenu_EmployeeFileCreate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "雇员资料创建";
								 case "zh-HK":
									 return "雇員資料創建";
								  case "en-US":
									 return "Employee File Create";
 								 
 								 default:									 
									 return "Employee File Create";
							} 
 					}
				}


				 ///<summary>第三方服務1</summary>
				public static string LeftMenu_EmployeeList_The3Rd_MenuTitle
				{
					get
					{


						if ("IN00001_LeftMenu_EmployeeList_The3Rd_MenuTitle".Contains(LangUtilities.IndustryCode))
						{
 							return Lang.IN00001_LeftMenu_EmployeeList_The3Rd_MenuTitle; 
						}
						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方服务1";
								 case "zh-HK":
									 return "第三方服務1";
								  case "en-US":
									 return "The 3rd Party Service 1";
 								 
 								 default:									 
									 return "The 3rd Party Service 1";
							} 
 					}
				}


				 ///<summary>雇員資料管理</summary>
				public static string LeftMenu_EmployeeManage
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "雇员资料管理";
								 case "zh-HK":
									 return "雇員資料管理";
								  case "en-US":
									 return "Employee Manage";
 								 
 								 default:									 
									 return "Employee Manage";
							} 
 					}
				}


				 ///<summary>考勤員工列表</summary>
				public static string LeftMenu_EmployeeSearchList
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤员工列表";
								 case "zh-HK":
									 return "考勤員工列表";
								  case "en-US":
									 return "Employee List";
 								 
 								 default:									 
									 return "Employee List";
							} 
 					}
				}


				 ///<summary>基礎數據</summary>
				public static string LeftMenu_FoundationData
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "基础数据";
								 case "zh-HK":
									 return "基礎數據";
								  case "en-US":
									 return "Foundation Data";
 								 
 								 default:									 
									 return "Foundation Data";
							} 
 					}
				}


				 ///<summary>假期與請假</summary>
				public static string LeftMenu_LeaveAndHoliday
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "假期与请假";
								 case "zh-HK":
									 return "假期與請假";
								  case "en-US":
									 return "Leave And Holiday";
 								 
 								 default:									 
									 return "Leave And Holiday";
							} 
 					}
				}


				 ///<summary>請假與審批</summary>
				public static string LeftMenu_LeaveApprovalList
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请假与审批";
								 case "zh-HK":
									 return "請假與審批";
								  case "en-US":
									 return "Leave Approval List";
 								 
 								 default:									 
									 return "Leave Approval List";
							} 
 					}
				}


				 ///<summary>考勤設置列表</summary>
				public static string LeftMenu_ShiftList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤设置列表";
								 case "zh-HK":
									 return "考勤設置列表";
								  case "en-US":
									 return "Shift List";
 								 
 								 default:									 
									 return "Shift List";
							} 
 					}
				}


				 ///<summary>日間考勤設置</summary>
				public static string LeftMenu_ShiftSetting
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日间考勤设置";
								 case "zh-HK":
									 return "日間考勤設置";
								  case "en-US":
									 return "Day Shift Setting";
 								 
 								 default:									 
									 return "Day Shift Setting";
							} 
 					}
				}


				 ///<summary>夜間考勤設置</summary>
				public static string LeftMenu_ShiftSettingNight
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "夜间考勤设置";
								 case "zh-HK":
									 return "夜間考勤設置";
								  case "en-US":
									 return "Night Shift Setting";
 								 
 								 default:									 
									 return "Night Shift Setting";
							} 
 					}
				}


				 ///<summary>系統管理</summary>
				public static string LeftMenu_SystemManage
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统管理";
								 case "zh-HK":
									 return "系統管理";
								  case "en-US":
									 return "System Manage";
 								 
 								 default:									 
									 return "System Manage";
							} 
 					}
				}


				 ///<summary>系統業務設置</summary>
				public static string LeftMenu_SystemSeeting
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统业务设置";
								 case "zh-HK":
									 return "系統業務設置";
								  case "en-US":
									 return "Sys Bussiness Setting";
 								 
 								 default:									 
									 return "Sys Bussiness Setting";
							} 
 					}
				}


				 ///<summary>系統用戶</summary>
				public static string LeftMenu_SystemUser
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统用户";
								 case "zh-HK":
									 return "系統用戶";
								  case "en-US":
									 return "System User";
 								 
 								 default:									 
									 return "System User";
							} 
 					}
				}


				 ///<summary>第三方服務</summary>
				public static string LeftMenu_The3rdService
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方服务";
								 case "zh-HK":
									 return "第三方服務";
								  case "en-US":
									 return "The 3rd Party Service";
 								 
 								 default:									 
									 return "The 3rd Party Service";
							} 
 					}
				}


				 ///<summary>登陸返回</summary>
				public static string LoginPartialView_BackEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登陆返回";
								 case "zh-HK":
									 return "登陸返回";
								  case "en-US":
									 return "Back End";
 								 
 								 default:									 
									 return "Back End";
							} 
 					}
				}


				 ///<summary>登錄賬號</summary>
				public static string LoginViewModel_UserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "登录账号";
								 case "zh-HK":
									 return "登錄賬號";
								  case "en-US":
									 return "LogIn ID";
 								 
 								 default:									 
									 return "LogIn ID";
							} 
 					}
				}


				 ///<summary>CIC Reference No.</summary>
				public static string MainCom_CIC_ReferenceNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "CIC Reference No.";
								 case "zh-HK":
									 return "CIC Reference No.";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司簡稱</summary>
				public static string MainCom_CompanyAbbreviation
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司简称";
								 case "zh-HK":
									 return "公司簡稱";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司地址</summary>
				public static string MainCom_CompanyAddress
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司地址";
								 case "zh-HK":
									 return "公司地址";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司傳真</summary>
				public static string MainCom_CompanyFax
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司传真";
								 case "zh-HK":
									 return "公司傳真";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司Logo</summary>
				public static string MainCom_CompanyLogo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司Logo";
								 case "zh-HK":
									 return "公司Logo";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司與組織注冊</summary>
				public static string MainCom_CompanyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司与??注?";
								 case "zh-HK":
									 return "公司與組織注冊";
								  case "en-US":
									 return "Co. Or Org.";
 								 
 								 default:									 
									 return "Co. Or Org.";
							} 
 					}
				}


				 ///<summary>公司Logo</summary>
				public static string MainCom_CompanyNameLogo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司Logo";
								 case "zh-HK":
									 return "公司Logo";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司電話</summary>
				public static string MainCom_CompanyTel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司电话";
								 case "zh-HK":
									 return "公司電話";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司聯系人</summary>
				public static string MainCom_ContactName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司联系人";
								 case "zh-HK":
									 return "公司聯系人";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>聯系人手機</summary>
				public static string MainCom_ContactPhone
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "联系人手机";
								 case "zh-HK":
									 return "聯系人手機";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>合約編號</summary>
				public static string MainCom_ContractorNo
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "合约编号";
								 case "zh-HK":
									 return "合約編號";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>已經登記注冊公司或組織信息</summary>
				public static string MainCom_HasRegisted
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已经登记注册公司或组织信息";
								 case "zh-HK":
									 return "已經登記注冊公司或組織信息";
								  case "en-US":
									 return "Info of Co. or Org. has been registed";
 								 
 								 default:									 
									 return "Info of Co. or Org. has been registed";
							} 
 					}
				}


				 ///<summary>行業Id</summary>
				public static string MainCom_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业Id";
								 case "zh-HK":
									 return "行業Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>所屬行業</summary>
				public static string MainCom_IndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "所属行业";
								 case "zh-HK":
									 return "所屬行業";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>緯度</summary>
				public static string MainCom_Latitude
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "纬度";
								 case "zh-HK":
									 return "緯度";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>經度</summary>
				public static string MainCom_Longitude
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "经度";
								 case "zh-HK":
									 return "經度";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>MainComId</summary>
				public static string MainCom_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "MainComId";
								 case "zh-HK":
									 return "MainComId";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>操作日期</summary>
				public static string MainCom_OperatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作日期";
								 case "zh-HK":
									 return "操作日期";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>操作用戶</summary>
				public static string MainCom_OperatedUserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作用户";
								 case "zh-HK":
									 return "操作用戶";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>服務結束</summary>
				public static string MainCom_ServiceEndDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "服務結束";
								 case "zh-HK":
									 return "服務結束";
								  case "en-US":
									 return "ServiceEnd";
 								 
 								 default:									 
									 return "ServiceEnd";
							} 
 					}
				}


				 ///<summary>服務開始日期</summary>
				public static string MainCom_ServiceStartDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "服務開始日期";
								 case "zh-HK":
									 return "服務開始日期";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>服務狀態</summary>
				public static string MainCom_ServiceStatus
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "服務狀態";
								 case "zh-HK":
									 return "服務狀態";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>公司與組織注冊</summary>
				public static string MainComReg
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司与??注?";
								 case "zh-HK":
									 return "公司與組織注冊";
								  case "en-US":
									 return "CO.& ORG REG";
 								 
 								 default:									 
									 return "CO.& ORG REG";
							} 
 					}
				}


				 ///<summary>盡管用戶有關聯的公司(組織)ID,但是沒有記錄或不一致的ID。</summary>
				public static string MainComReg_StatusMessageMainComIdInconsistent
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "尽管用户有关联的公司(组织)ID,但是没有记录或不一致的ID。";
								 case "zh-HK":
									 return "盡管用戶有關聯的公司(組織)ID,但是沒有記錄或不一致的ID。";
								  case "en-US":
									 return "Although the user has an associated company (organization) ID, there is no record or inconsistency ID.";
 								 
 								 default:									 
									 return "Although the user has an associated company (organization) ID, there is no record or inconsistency ID.";
							} 
 					}
				}


				 ///<summary>使用本系統請先登記公司或組織信息！</summary>
				public static string MainComReg_StatusMessageTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "使用本系统请先登记公司或组织信息！";
								 case "zh-HK":
									 return "使用本系統請先登記公司或組織信息！";
								  case "en-US":
									 return "Please register company or organization information first to use this system!";
 								 
 								 default:									 
									 return "Please register company or organization information first to use this system!";
							} 
 					}
				}


				 ///<summary>管理外部登錄</summary>
				public static string ManageLogins_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "管理外部登录";
								 case "zh-HK":
									 return "管理外部登錄";
								  case "en-US":
									 return "Manage Logins";
 								 
 								 default:									 
									 return "Manage Logins";
							} 
 					}
				}


				 ///<summary>菜單名稱</summary>
				public static string MenuItem_EngMenuItemName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "菜单名称";
								 case "zh-HK":
									 return "菜單名稱";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>角色授權</summary>
				public static string MenuItem_ForRoleName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "角色授权";
								 case "zh-HK":
									 return "角色授權";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>菜單ID</summary>
				public static string MenuItem_MenuItemID
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "菜单ID";
								 case "zh-HK":
									 return "菜單ID";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>菜單名稱</summary>
				public static string MenuItem_MenuItemName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "菜单名称";
								 case "zh-HK":
									 return "菜單名稱";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>連接</summary>
				public static string MenuItem_MenuLink
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "连接";
								 case "zh-HK":
									 return "連接";
								  case "en-US":
									 return "Menu Link";
 								 
 								 default:									 
									 return "Menu Link";
							} 
 					}
				}


				 ///<summary>操作日期</summary>
				public static string MenuItem_OperatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作日期";
								 case "zh-HK":
									 return "操作日期";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>操作用戶</summary>
				public static string MenuItem_OperatedUserName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作用户";
								 case "zh-HK":
									 return "操作用戶";
								  case "en-US":
									 return "Operated User";
 								 
 								 default:									 
									 return "Operated User";
							} 
 					}
				}


				 ///<summary>父菜單ID</summary>
				public static string MenuItem_ParentsMenuItemID
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "父菜单ID";
								 case "zh-HK":
									 return "父菜單ID";
								  case "en-US":
									 return "Parents MenuItem ID";
 								 
 								 default:									 
									 return "Parents MenuItem ID";
							} 
 					}
				}


				 ///<summary>打開方式</summary>
				public static string MenuItem_Target
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "打开方式";
								 case "zh-HK":
									 return "打開方式";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>月度統計報表</summary>
				public static string MonthStatistics_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "月度统计报表";
								 case "zh-HK":
									 return "月度統計報表";
								  case "en-US":
									 return "Monthly Statistics Resports";
 								 
 								 default:									 
									 return "Monthly Statistics Resports";
							} 
 					}
				}


				 ///<summary>設備未打開NFC功能</summary>
				public static string NFCTAP_NeedToOpenNFC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设备未打开NFC功能";
								 case "zh-HK":
									 return "設備未打開NFC功能";
								  case "en-US":
									 return "Need to open NFC";
 								 
 								 default:									 
									 return "Need to open NFC";
							} 
 					}
				}


				 ///<summary>設備不支持NFC功能</summary>
				public static string NFCTAP_NotSupportNFC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设备不支持NFC功能";
								 case "zh-HK":
									 return "設備不支持NFC功能";
								  case "en-US":
									 return "No NFC";
 								 
 								 default:									 
									 return "No NFC";
							} 
 					}
				}


				 ///<summary>創建日期</summary>
				public static string Position_CreatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "创建日期";
								 case "zh-HK":
									 return "創建日期";
								  case "en-US":
									 return "CreatedDate";
 								 
 								 default:									 
									 return "CreatedDate";
							} 
 					}
				}


				 ///<summary>CreatedDate2</summary>
				public static string Position_CreatedDate2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "CreatedDate2";
								 case "zh-HK":
									 return "CreatedDate2";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>Eng Title</summary>
				public static string Position_EnPositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Eng Title";
								 case "zh-HK":
									 return "Eng Title";
								  case "en-US":
									 return "English Title";
 								 
 								 default:									 
									 return "English Title";
							} 
 					}
				}


				 ///<summary>Industry Id</summary>
				public static string Position_IndustryId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Industry Id";
								 case "zh-HK":
									 return "Industry Id";
								  case "en-US":
									 return "";
 								 
 								 default:									 
									 return "";
							} 
 					}
				}


				 ///<summary>行業名稱</summary>
				public static string Position_IndustryName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业名称";
								 case "zh-HK":
									 return "行業名稱";
								  case "en-US":
									 return "Industry Name";
 								 
 								 default:									 
									 return "Industry Name";
							} 
 					}
				}


				 ///<summary>不存在的職位記錄</summary>
				public static string Position_NotExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "不存在的职位记录";
								 case "zh-HK":
									 return "不存在的職位記錄";
								  case "en-US":
									 return "This position is not exist record!";
 								 
 								 default:									 
									 return "This position is not exist record!";
							} 
 					}
				}


				 ///<summary>新增職位</summary>
				public static string Position_PositionAddNew_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新增职位";
								 case "zh-HK":
									 return "新增職位";
								  case "en-US":
									 return "Add a new position";
 								 
 								 default:									 
									 return "Add a new position";
							} 
 					}
				}


				 ///<summary>Position Id</summary>
				public static string Position_PositionId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Position Id";
								 case "zh-HK":
									 return "Position Id";
								  case "en-US":
									 return "Position Id";
 								 
 								 default:									 
									 return "Position Id";
							} 
 					}
				}


				 ///<summary>Title</summary>
				public static string Position_PositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Title";
								 case "zh-HK":
									 return "Title";
								  case "en-US":
									 return "Title";
 								 
 								 default:									 
									 return "Title";
							} 
 					}
				}


				 ///<summary>存在的職位名稱</summary>
				public static string PositionAddNew_ExistTheSamePositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在的职位名称";
								 case "zh-HK":
									 return "存在的職位名稱";
								  case "en-US":
									 return "This position title is exist !";
 								 
 								 default:									 
									 return "This position title is exist !";
							} 
 					}
				}


				 ///<summary>好吧！再考慮一下吧！</summary>
				public static string PositionList_ComfirmNoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "好吧！再考虑一下吧！";
								 case "zh-HK":
									 return "好吧！再考慮一下吧！";
								  case "en-US":
									 return "OK! Think about it again!";
 								 
 								 default:									 
									 return "OK! Think about it again!";
							} 
 					}
				}


				 ///<summary>確定刪除當前職位嗎？</summary>
				public static string PositionList_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确定删除当前职位吗？";
								 case "zh-HK":
									 return "確定刪除當前職位嗎？";
								  case "en-US":
									 return "Comfirm delete this position?";
 								 
 								 default:									 
									 return "Comfirm delete this position?";
							} 
 					}
				}


				 ///<summary>已存在使用的職位，如果刪除，會影響數據完整性！</summary>
				public static string PositionList_ComfirmTips2
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已存在使用的职位，如果删除，会影响数据完整性！";
								 case "zh-HK":
									 return "已存在使用的職位，如果刪除，會影響數據完整性！";
								  case "en-US":
									 return "Deleted this position record,It may cause the data integrity!";
 								 
 								 default:									 
									 return "Deleted this position record,It may cause the data integrity!";
							} 
 					}
				}


				 ///<summary>職位編輯</summary>
				public static string PositionList_EditPositionDetails_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "职位编辑";
								 case "zh-HK":
									 return "職位編輯";
								  case "en-US":
									 return "Position Edit";
 								 
 								 default:									 
									 return "Position Edit";
							} 
 					}
				}


				 ///<summary>職位列表</summary>
				public static string PositionList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "职位列表";
								 case "zh-HK":
									 return "職位列表";
								  case "en-US":
									 return "Position List";
 								 
 								 default:									 
									 return "Position List";
							} 
 					}
				}


				 ///<summary>遁入空門啊！請填入相關信息</summary>
				public static string QuickAddIdNumber_IsBlank
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "遁入空门啊！请填入相关信息";
								 case "zh-HK":
									 return "遁入空門啊！請填入相關信息";
								  case "en-US":
									 return "遁入空門啊！please input relate info!";
 								 
 								 default:									 
									 return "遁入空門啊！please input relate info!";
							} 
 					}
				}


				 ///<summary>身份</summary>
				public static string QuickAddIdNumber_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "身份";
								 case "zh-HK":
									 return "身份";
								  case "en-US":
									 return "Identity";
 								 
 								 default:									 
									 return "Identity";
							} 
 					}
				}


				 ///<summary>組織單元</summary>
				public static string QuickAddOganization_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "所属部门";
								 case "zh-HK":
									 return "所屬部門";
								  case "en-US":
									 return "所屬部門";
 								 
 								 default:									 
									 return "所屬部門";
							} 
 					}
				}


				 ///<summary>識別特征</summary>
				public static string QuickAddRecognition_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "识别特征";
								 case "zh-HK":
									 return "識別特征";
								  case "en-US":
									 return "Recognition";
 								 
 								 default:									 
									 return "Recognition";
							} 
 					}
				}


				 ///<summary>請輸入手機號碼或者電子郵件以及長度的5-30、由字母和數字組成賬號</summary>
				public static string Register_AccountFormatError
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入手机号码或者电子邮件以及由长度5-30字母和数字组成的账号";
								 case "zh-HK":
									 return "請輸入手機號碼或者電子郵件以及長度的5-30、由字母和數字組成賬號";
								  case "en-US":
									 return "Please enter your mobile number or email and 5-30 accounts consisting of letters and numbers.";
 								 
 								 default:									 
									 return "Please enter your mobile number or email and 5-30 accounts consisting of letters and numbers.";
							} 
 					}
				}


				 ///<summary>確認密碼</summary>
				public static string RegisterViewModel_ConfirmPassword
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确认密码";
								 case "zh-HK":
									 return "確認密碼";
								  case "en-US":
									 return "Confirmed Password";
 								 
 								 default:									 
									 return "Confirmed Password";
							} 
 					}
				}


				 ///<summary>Email或手機號</summary>
				public static string RegisterViewModel_EmailPhoneOrName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email或手机号";
								 case "zh-HK":
									 return "Email或手機號";
								  case "en-US":
									 return "Email,Phone,Name";
 								 
 								 default:									 
									 return "Email,Phone,Name";
							} 
 					}
				}


				 ///<summary>已經注冊賬號</summary>
				public static string RegisterViewModel_HasRegistedToLogin
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "已经注册账号";
								 case "zh-HK":
									 return "已經注冊賬號";
								  case "en-US":
									 return "I Have Registed";
 								 
 								 default:									 
									 return "I Have Registed";
							} 
 					}
				}


				 ///<summary>使用Email注冊</summary>
				public static string RegisterViewModel_LoginNameTooltip
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "使用Email注册";
								 case "zh-HK":
									 return "使用Email注冊";
								  case "en-US":
									 return "Email";
 								 
 								 default:									 
									 return "Email";
							} 
 					}
				}


				 ///<summary>用戶注冊</summary>
				public static string RegisterViewModel_RegisterAsNewMember
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用户注册";
								 case "zh-HK":
									 return "用戶注冊";
								  case "en-US":
									 return "Register a New Id";
 								 
 								 default:									 
									 return "Register a New Id";
							} 
 					}
				}


				 ///<summary>注册</summary>
				public static string RegisterViewModel_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注册";
								 case "zh-HK":
									 return "注册";
								  case "en-US":
									 return "Register";
 								 
 								 default:									 
									 return "Register";
							} 
 					}
				}


				 ///<summary>Welcome</summary>
				public static string RegisterViewModel_Welcome
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Welcome";
								 case "zh-HK":
									 return "Welcome";
								  case "en-US":
									 return "Welcome";
 								 
 								 default:									 
									 return "Welcome";
							} 
 					}
				}


				 ///<summary>提供給客戶（公司）管理員使用。具有最高對全權權限。</summary>
				public static string Roles_Admin
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "提供给客户（公司）管理员使用。具有最高对全权权限。";
								 case "zh-HK":
									 return "提供給客戶（公司）管理員使用。具有最高對全權權限。";
								  case "en-US":
									 return "Main commpany administrator ( client admin account)";
 								 
 								 default:									 
									 return "Main commpany administrator ( client admin account)";
							} 
 					}
				}


				 ///<summary>僱員使用 包括閱覽、申請、查詢</summary>
				public static string Roles_Employee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "for  雇员使用 包括阅览、申请、查询";
								 case "zh-HK":
									 return "僱員使用 包括閱覽、申請、查詢";
								  case "en-US":
									 return "For Main commpany or contractor Employee";
 								 
 								 default:									 
									 return "For Main commpany or contractor Employee";
							} 
 					}
				}


				 ///<summary>for 訪客身份</summary>
				public static string Roles_Guest
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "for  访客身份";
								 case "zh-HK":
									 return "for 訪客身份";
								  case "en-US":
									 return "For Guest";
 								 
 								 default:									 
									 return "For Guest";
							} 
 					}
				}


				 ///<summary>監管機構或第三方或政府監察部門瀏覽</summary>
				public static string Roles_LRO
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "监管机构或第三方或政府监察部门浏览";
								 case "zh-HK":
									 return "監管機構或第三方或政府監察部門瀏覽";
								  case "en-US":
									 return "Browse by regulatory agencies or government supervision departments";
 								 
 								 default:									 
									 return "Browse by regulatory agencies or government supervision departments";
							} 
 					}
				}


				 ///<summary>總公司操作員</summary>
				public static string Roles_MainComOperator
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "总公司操作员";
								 case "zh-HK":
									 return "總公司操作員";
								  case "en-US":
									 return "Head office operator";
 								 
 								 default:									 
									 return "Head office operator";
							} 
 					}
				}


				 ///<summary>系統超級管理員</summary>
				public static string Roles_SystemAdmin
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统超级管理员";
								 case "zh-HK":
									 return "系統超級管理員";
								  case "en-US":
									 return "System Super Administrator";
 								 
 								 default:									 
									 return "System Super Administrator";
							} 
 					}
				}


				 ///<summary>受托方或服務商的管理員</summary>
				public static string Roles_ThirdPartyserviceContractorAdmin
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "受托方或服务商的管理员";
								 case "zh-HK":
									 return "受托方或服務商的管理員";
								  case "en-US":
									 return "Administrator of the trustee or service provider";
 								 
 								 default:									 
									 return "Administrator of the trustee or service provider";
							} 
 					}
				}


				 ///<summary>受托方或服務商的操作員</summary>
				public static string Roles_ThirdPartyserviceContractorOperator
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "受托方或服务商的操作员";
								 case "zh-HK":
									 return "受托方或服務商的操作員";
								  case "en-US":
									 return "Operator of the trustee or service provider";
 								 
 								 default:									 
									 return "Operator of the trustee or service provider";
							} 
 					}
				}


				 ///<summary>請填入各項評估值，0%不合理。</summary>
				public static string Salary_SalaryAssessPercent_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请填入各项评估值，0%不合理。";
								 case "zh-HK":
									 return "請填入各項評估值，0%不合理。";
								  case "en-US":
									 return "Please fill in the evaluation values, 0% is unreasonable.";
 								 
 								 default:									 
									 return "Please fill in the evaluation values, 0% is unreasonable.";
							} 
 					}
				}


				 ///<summary>請填入最大評估參考值。</summary>
				public static string Salary_SalaryMaxValue_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请填入最大评估参考值。";
								 case "zh-HK":
									 return "請填入最大評估參考值。";
								  case "en-US":
									 return "Please fill in the maximum evaluation reference value.";
 								 
 								 default:									 
									 return "Please fill in the maximum evaluation reference value.";
							} 
 					}
				}


				 ///<summary>無效的薪酬評估值（0）</summary>
				public static string SalaryAssessment_InvlidAssessValue
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无效的薪酬评估值（0）";
								 case "zh-HK":
									 return "無效的薪酬評估值（0）";
								  case "en-US":
									 return "Invlid Value Of Salary Assessment";
 								 
 								 default:									 
									 return "Invlid Value Of Salary Assessment";
							} 
 					}
				}


				 ///<summary>薪酬評估</summary>
				public static string SalaryAssessment_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "薪酬评估";
								 case "zh-HK":
									 return "薪酬評估";
								  case "en-US":
									 return "Salary Assessment";
 								 
 								 default:									 
									 return "Salary Assessment";
							} 
 					}
				}


				 ///<summary>能力</summary>
				public static string SalAssessment_Ability
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "能力";
								 case "zh-HK":
									 return "能力";
								  case "en-US":
									 return "Ability";
 								 
 								 default:									 
									 return "Ability";
							} 
 					}
				}


				 ///<summary>審批人</summary>
				public static string SalAssessment_ApprovedBy
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "审批人";
								 case "zh-HK":
									 return "審批人";
								  case "en-US":
									 return "Approved By";
 								 
 								 default:									 
									 return "Approved By";
							} 
 					}
				}


				 ///<summary>YES:審核通過；NO:拒绝</summary>
				public static string SalAssessment_ApprovedComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "YES:审核通过；NO:拒绝";
								 case "zh-HK":
									 return "YES:審核通過；NO:拒绝";
								  case "en-US":
									 return "YES:APPROVED；NO:REJECTED";
 								 
 								 default:									 
									 return "YES:APPROVED；NO:REJECTED";
							} 
 					}
				}


				 ///<summary>教育</summary>
				public static string SalAssessment_Education
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "教育";
								 case "zh-HK":
									 return "教育";
								  case "en-US":
									 return "Education";
 								 
 								 default:									 
									 return "Education";
							} 
 					}
				}


				 ///<summary>評估人</summary>
				public static string SalAssessment_EvaluatedBy
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "评估人";
								 case "zh-HK":
									 return "評估人";
								  case "en-US":
									 return "Evaluated By";
 								 
 								 default:									 
									 return "Evaluated By";
							} 
 					}
				}


				 ///<summary>經驗評估</summary>
				public static string SalAssessment_Experience
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "经验评估";
								 case "zh-HK":
									 return "經驗評估";
								  case "en-US":
									 return "Experience Assessment";
 								 
 								 default:									 
									 return "Experience Assessment";
							} 
 					}
				}


				 ///<summary>家庭評估</summary>
				public static string SalAssessment_Family
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "家庭评估";
								 case "zh-HK":
									 return "家庭評估";
								  case "en-US":
									 return "Family Assessment";
 								 
 								 default:									 
									 return "Family Assessment";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string SalAssessment_FullName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "Name";
 								 
 								 default:									 
									 return "Name";
							} 
 					}
				}


				 ///<summary>行業操守</summary>
				public static string SalAssessment_IndustryEthics
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业操守";
								 case "zh-HK":
									 return "行業操守";
								  case "en-US":
									 return "_Industry Ethics";
 								 
 								 default:									 
									 return "_Industry Ethics";
							} 
 					}
				}


				 ///<summary>行業聲譽評估</summary>
				public static string SalAssessment_IndustryReputation
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "行业声誉评估";
								 case "zh-HK":
									 return "行業聲譽評估";
								  case "en-US":
									 return "Industry Reputation";
 								 
 								 default:									 
									 return "Industry Reputation";
							} 
 					}
				}


				 ///<summary>請輸入行業最大薪酬值。例如：行業最大薪酬值是100000。10萬，則輸入最大值十萬。</summary>
				public static string SalAssessment_InputTheAssessmentMaxValueTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入行业最大薪酬值。例如：行业最大薪酬值是100000。10万，则输入最大值十万。";
								 case "zh-HK":
									 return "請輸入行業最大薪酬值。例如：行業最大薪酬值是100000。10萬，則輸入最大值十萬。";
								  case "en-US":
									 return "Please enter the industrys maximum salary value. For example: the industry’s maximum salary value is 100,000. 100,000, then enter the maximum value of 100,000.";
 								 
 								 default:									 
									 return "Please enter the industrys maximum salary value. For example: the industry’s maximum salary value is 100,000. 100,000, then enter the maximum value of 100,000.";
							} 
 					}
				}


				 ///<summary>臨時評估</summary>
				public static string SalAssessment_IsTempAssessment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "临时评估";
								 case "zh-HK":
									 return "臨時評估";
								  case "en-US":
									 return "Temp Assessment";
 								 
 								 default:									 
									 return "Temp Assessment";
							} 
 					}
				}


				 ///<summary>臨時評估適用于面試等的需要，而關聯對應雇員，適合雋升評估等需要。</summary>
				public static string SalAssessment_IsTempAssessmentTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "临时评估适用于面试等的需要，而关联对应雇员，适合隽升评估等需要。";
								 case "zh-HK":
									 return "臨時評估適用于面試等的需要，而關聯對應雇員，適合雋升評估等需要。";
								  case "en-US":
									 return "Temporary evaluation is suitable for interviews and other needs, while the association corresponds to employees, which is suitable for high-level evaluation and other needs.";
 								 
 								 default:									 
									 return "Temporary evaluation is suitable for interviews and other needs, while the association corresponds to employees, which is suitable for high-level evaluation and other needs.";
							} 
 					}
				}


				 ///<summary>婚姻評估</summary>
				public static string SalAssessment_Marriage
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "婚姻评估";
								 case "zh-HK":
									 return "婚姻評估";
								  case "en-US":
									 return "Marriage Assessment";
 								 
 								 default:									 
									 return "Marriage Assessment";
							} 
 					}
				}


				 ///<summary>沒有評分權重的計算結果</summary>
				public static string SalAssessment_NoScoreWeightTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有评分权重的计算结果";
								 case "zh-HK":
									 return "沒有評分權重的計算結果";
								  case "en-US":
									 return "Calculation result without scoring weight";
 								 
 								 default:									 
									 return "Calculation result without scoring weight";
							} 
 					}
				}


				 ///<summary>操作日期</summary>
				public static string SalAssessment_OperateDateTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "操作日期";
								 case "zh-HK":
									 return "操作日期";
								  case "en-US":
									 return "Operate Date";
 								 
 								 default:									 
									 return "Operate Date";
							} 
 					}
				}


				 ///<summary>資格評估</summary>
				public static string SalAssessment_Qualifications
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "资格评估";
								 case "zh-HK":
									 return "資格評估";
								  case "en-US":
									 return "Qualifications Assessment";
 								 
 								 default:									 
									 return "Qualifications Assessment";
							} 
 					}
				}


				 ///<summary>綜合評估值</summary>
				public static string SalAssessment_SalaryAssessmentValue
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "综合评估值";
								 case "zh-HK":
									 return "綜合評估值";
								  case "en-US":
									 return "Salary Assessment Value";
 								 
 								 default:									 
									 return "Salary Assessment Value";
							} 
 					}
				}


				 ///<summary>目標最大值</summary>
				public static string SalAssessment_SalaryMaxValue
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "目标最大值";
								 case "zh-HK":
									 return "目標最大值";
								  case "en-US":
									 return "Salary Max Value";
 								 
 								 default:									 
									 return "Salary Max Value";
							} 
 					}
				}


				 ///<summary>請先輸入目標評估最大值。假設最理想狀態下，完全符合最優秀標準下的薪酬待遇，則此薪酬值為目標薪酬最大值。</summary>
				public static string SalAssessment_SalaryMaxValueTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请先输入目标评估最大值。假设最理想状态下，完全符合最优秀标准下的薪酬待遇，则此薪酬值为目标薪酬最大值。";
								 case "zh-HK":
									 return "請先輸入目標評估最大值。假設最理想狀態下，完全符合最優秀標準下的薪酬待遇，則此薪酬值為目標薪酬最大值。";
								  case "en-US":
									 return "Please enter the target evaluation maximum value first. Assuming that in the ideal state, the salary package under the best standard is fully met, the salary value is the maximum value of the target salary.";
 								 
 								 default:									 
									 return "Please enter the target evaluation maximum value first. Assuming that in the ideal state, the salary package under the best standard is fully met, the salary value is the maximum value of the target salary.";
							} 
 					}
				}


				 ///<summary>評分權重(累計100分)</summary>
				public static string SalAssessment_ScoreWeight
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "评分权重(累计100分)";
								 case "zh-HK":
									 return "評分權重(累計100分)";
								  case "en-US":
									 return "Score Weight(100 points accumulated)";
 								 
 								 default:									 
									 return "Score Weight(100 points accumulated)";
							} 
 					}
				}


				 ///<summary>結算周期</summary>
				public static string SalAssessment_SettlePeriodMode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "结算周期";
								 case "zh-HK":
									 return "結算周期";
								  case "en-US":
									 return "Settle Period";
 								 
 								 default:									 
									 return "Settle Period";
							} 
 					}
				}


				 ///<summary>結算模式規則：每人只能有一種結算模式，例如：時薪結算模式，則只有一條記錄。重新錄入則需要刪除當前結算模式。注意：定期調度計算薪酬的時候，如果沒有該結算模式，則會導致沒有此選項的計算。例如：每月薪酬，錯誤把月度薪酬評估刪除，將會導致本月無法出薪酬報表和財務報表缺失該計算等。</summary>
				public static string SalAssessment_SettlePeriodModeTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "结算模式规则：每人只能有一种结算模式，例如：时薪结算模式，则只有一条记录。重新录入则需要删除当前结算模式。注意：定期调度计算薪酬的时候，如果没有该结算模式，则会导致没有此选项的计算。例如：每月薪酬，错误把月度薪酬评估删除，将会导致本月无法出薪酬报表和财务报表缺失该计算等。";
								 case "zh-HK":
									 return "結算模式規則：每人只能有一種結算模式，例如：時薪結算模式，則只有一條記錄。重新錄入則需要刪除當前結算模式。注意：定期調度計算薪酬的時候，如果沒有該結算模式，則會導致沒有此選項的計算。例如：每月薪酬，錯誤把月度薪酬評估刪除，將會導致本月無法出薪酬報表和財務報表缺失該計算等。";
								  case "en-US":
									 return "Settlement mode rules: each person can only have one salary settlement mode, for example: hourly salary settlement mode, there is only one record. To re-enter, you need to delete the current salary settlement mode. Note: When the salary is calculated by monthly schedule, if the settlement mode is not available, it will result in no calculation of this option. For example: monthly salary, if the monthly salary evaluation is deleted by mistake, the salary statement will not be issued this month and the financial statement will be missing the calculation.";
 								 
 								 default:									 
									 return "Settlement mode rules: each person can only have one salary settlement mode, for example: hourly salary settlement mode, there is only one record. To re-enter, you need to delete the current salary settlement mode. Note: When the salary is calculated by monthly schedule, if the settlement mode is not available, it will result in no calculation of this option. For example: monthly salary, if the monthly salary evaluation is deleted by mistake, the salary statement will not be issued this month and the financial statement will be missing the calculation.";
							} 
 					}
				}


				 ///<summary>沒有關聯的員工，審核薪酬毫無意義。(錄入時選擇了臨時評估）</summary>
				public static string SalAssessmentApproved_NoEmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有关联的员工，审核薪酬毫无意义。(录入时选择了临时评估）";
								 case "zh-HK":
									 return "沒有關聯的員工，審核薪酬毫無意義。(錄入時選擇了臨時評估）";
								  case "en-US":
									 return "Without associated employees, there is no point in reviewing compensation. (Temporary evaluation was selected during entry)";
 								 
 								 default:									 
									 return "Without associated employees, there is no point in reviewing compensation. (Temporary evaluation was selected during entry)";
							} 
 					}
				}


				 ///<summary>刪除將會導致月度/周度/年度等的薪酬計算缺失此項。如需要新的評估審核，則需要刪除舊的年/月/日/時度薪酬評估。</summary>
				public static string SalAssessmentDelete_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "删除将会导致月度/周度/年度等的薪酬计算缺失此项。如需要新的评估审核，则需要删除旧的年/月/日/时度薪酬评估。";
								 case "zh-HK":
									 return "刪除將會導致月度/周度/年度等的薪酬計算缺失此項。如需要新的評估審核，則需要刪除舊的年/月/日/時度薪酬評估。";
								  case "en-US":
									 return "Deleting will result in missing this item in the monthly/yearly/weekly/dayly/hourly salary calculation";
 								 
 								 default:									 
									 return "Deleting will result in missing this item in the monthly/yearly/weekly/dayly/hourly salary calculation";
							} 
 					}
				}


				 ///<summary>沒有排班安排</summary>
				public static string Schedule_NoScheduleAsigned
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有排班安排";
								 case "zh-HK":
									 return "沒有排班安排";
								  case "en-US":
									 return "No schedule asigned";
 								 
 								 default:									 
									 return "No schedule asigned";
							} 
 					}
				}


				 ///<summary>建議最大日期段為31天</summary>
				public static string Schedule_ScheduleDateRangeIllegal
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "建议最大日期段为31天";
								 case "zh-HK":
									 return "建議最大日期段為31天";
								  case "en-US":
									 return "The recommended maximum date range is 31 days";
 								 
 								 default:									 
									 return "The recommended maximum date range is 31 days";
							} 
 					}
				}


				 ///<summary>排班ID</summary>
				public static string Schedule_ScheduleId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班ID";
								 case "zh-HK":
									 return "排班ID";
								  case "en-US":
									 return "Schedule Id";
 								 
 								 default:									 
									 return "Schedule Id";
							} 
 					}
				}


				 ///<summary>排更名冊圖表</summary>
				public static string ScheduleChart_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班名冊圖表";
								 case "zh-HK":
									 return "排更名冊圖表";
								  case "en-US":
									 return "Schedule Chart View";
 								 
 								 default:									 
									 return "Schedule Chart View";
							} 
 					}
				}


				 ///<summary>考勤人數少於100人，視圖效果并不理想哦。此處不建議使用！</summary>
				public static string ScheduleChartSearching_LessThan100Tips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤人数少於100人，视图效果并不理想哦。此处不建议使用！";
								 case "zh-HK":
									 return "考勤人數少於100人，視圖效果并不理想哦。此處不建議使用！";
								  case "en-US":
									 return "If the number of attendances is less than 100, the Chart doesn't looked good view. Not recommended here!";
 								 
 								 default:									 
									 return "If the number of attendances is less than 100, the Chart doesn't looked good view. Not recommended here!";
							} 
 					}
				}


				 ///<summary>考勤編號簡稱對照</summary>
				public static string Scheduleindex_ShiftRemarksTitle_Rpt
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤编号简称对照";
								 case "zh-HK":
									 return "考勤編號簡稱對照";
								  case "en-US":
									 return "Shift Abbr.ID";
 								 
 								 default:									 
									 return "Shift Abbr.ID";
							} 
 					}
				}


				 ///<summary>排班名冊列表</summary>
				public static string ScheduleIndex_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班名册列表";
								 case "zh-HK":
									 return "排班名冊列表";
								  case "en-US":
									 return "Schedule Roster";
 								 
 								 default:									 
									 return "Schedule Roster";
							} 
 					}
				}


				 ///<summary>日結薪酬</summary>
				public static string SettlePeriodMode_Day
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日结薪酬";
								 case "zh-HK":
									 return "日結薪酬";
								  case "en-US":
									 return "Dayly salary";
 								 
 								 default:									 
									 return "Dayly salary";
							} 
 					}
				}


				 ///<summary>時結薪酬</summary>
				public static string SettlePeriodMode_Hour
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "时结薪酬";
								 case "zh-HK":
									 return "時結薪酬";
								  case "en-US":
									 return "Hourly salary";
 								 
 								 default:									 
									 return "Hourly salary";
							} 
 					}
				}


				 ///<summary>月結薪酬</summary>
				public static string SettlePeriodMode_Month
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "月结薪酬";
								 case "zh-HK":
									 return "月結薪酬";
								  case "en-US":
									 return "Monthly salary";
 								 
 								 default:									 
									 return "Monthly salary";
							} 
 					}
				}


				 ///<summary>結算周期規則提示：不能同時存在多個同一周期的結算記錄。</summary>
				public static string SettlePeriodMode_RuleTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "结算周期规则提示：不能同时存在多个同一周期的结算记录。";
								 case "zh-HK":
									 return "結算周期規則提示：不能同時存在多個同一周期的結算記錄。";
								  case "en-US":
									 return "Settlement cycle rule reminder: multiple settlement records of the same cycle cannot exist at the same time.";
 								 
 								 default:									 
									 return "Settlement cycle rule reminder: multiple settlement records of the same cycle cannot exist at the same time.";
							} 
 					}
				}


				 ///<summary>周結薪酬</summary>
				public static string SettlePeriodMode_Week
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "周结薪酬";
								 case "zh-HK":
									 return "周結薪酬";
								  case "en-US":
									 return "Weekly salary";
 								 
 								 default:									 
									 return "Weekly salary";
							} 
 					}
				}


				 ///<summary>年結薪酬</summary>
				public static string SettlePeriodMode_Year
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "年结薪酬";
								 case "zh-HK":
									 return "年結薪酬";
								  case "en-US":
									 return "Yearly salary";
 								 
 								 default:									 
									 return "Yearly salary";
							} 
 					}
				}


				 ///<summary>應用結束日期</summary>
				public static string Shift_AppliedEndDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "应用结束日期";
								 case "zh-HK":
									 return "應用結束日期";
								  case "en-US":
									 return "Applied End Date";
 								 
 								 default:									 
									 return "Applied End Date";
							} 
 					}
				}


				 ///<summary>開始應用</summary>
				public static string Shift_AppliedStartDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "开始应用";
								 case "zh-HK":
									 return "開始應用";
								  case "en-US":
									 return "Applied Start";
 								 
 								 default:									 
									 return "Applied Start";
							} 
 					}
				}


				 ///<summary>應用開始日期與應用結束日期不合理</summary>
				public static string Shift_AppliedStartDateIsNotLogical_Validator
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "应用开始日期与应用结束日期不合理";
								 case "zh-HK":
									 return "應用開始日期與應用結束日期不合理";
								  case "en-US":
									 return "Applied start date and Applied end date are not reasonable";
 								 
 								 default:									 
									 return "Applied start date and Applied end date are not reasonable";
							} 
 					}
				}


				 ///<summary>按部門指派考勤設置</summary>
				public static string Shift_AsignedByDepartment
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "按部门指派考勤设置";
								 case "zh-HK":
									 return "按部門指派考勤設置";
								  case "en-US":
									 return "Assinged by department";
 								 
 								 default:									 
									 return "Assinged by department";
							} 
 					}
				}


				 ///<summary>考勤容許多少分鐘</summary>
				public static string Shift_AttendanceAllowance
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤容许多少分钟";
								 case "zh-HK":
									 return "考勤容許多少分鐘";
								  case "en-US":
									 return "Attendance Allowance";
 								 
 								 default:									 
									 return "Attendance Allowance";
							} 
 					}
				}


				 ///<summary>考勤允許值：指的是上下班遲到或早退，在指定范圍時間內，不作早退或遲到，例如：9:01后上班就開始算作遲到，但加入允許值15分鐘，9:16后才算是遲到，早退同理。午餐、加班同樣適用。</summary>
				public static string Shift_AttendanceAllowanceTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤允许值：指的是上下班迟到或早退，在指定范围时间内，不作早退或迟到，例如：9:01后上班就开始算作迟到，但加入允许值15分钟，9:16后才算是迟到，早退同理。午餐、加班同样适用。";
								 case "zh-HK":
									 return "考勤允許值：指的是上下班遲到或早退，在指定范圍時間內，不作早退或遲到，例如：9:01后上班就開始算作遲到，但加入允許值15分鐘，9:16后才算是遲到，早退同理。午餐、加班同樣適用。";
								  case "en-US":
									 return "Attendance allowable value: refers to late or early leave of work, not early or late in the specified range of time, for example: 9:01 after work is counted as late, but the allowed value is 15 minutes, after 9:16 is considered Being late, leaving the same way.Lunch and overtime work are also available.";
 								 
 								 default:									 
									 return "Attendance allowable value: refers to late or early leave of work, not early or late in the specified range of time, for example: 9:01 after work is counted as late, but the allowed value is 15 minutes, after 9:16 is considered Being late, leaving the same way.Lunch and overtime work are also available.";
							} 
 					}
				}


				 ///<summary>有效考勤時間段</summary>
				public static string Shift_AttendanceWorkBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "有效考勤时间段";
								 case "zh-HK":
									 return "有效考勤時間段";
								  case "en-US":
									 return "Valid Attendance Time Buffer";
 								 
 								 default:									 
									 return "Valid Attendance Time Buffer";
							} 
 					}
				}


				 ///<summary>允许上班时间9:00前後2小時為有效考勤時間段，最早的有效记录时间，例如 7:00-9:00 的记录有效。早于7:00和晚於11:00视为无效考勤时间</summary>
				public static string Shift_AttendanceWorkBufferTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "允许上班时间9:00前后2小时为有效考勤时间段，初步的有效记录时间，例如7：00-9：00的记录有效。早于7:00和晚于11:00无效考勤时间";
								 case "zh-HK":
									 return "允许上班时间9:00前後2小時為有效考勤時間段，最早的有效记录时间，例如 7:00-9:00 的记录有效。早于7:00和晚於11:00视为无效考勤时间";
								  case "en-US":
									 return "Allows the earliest and the latest valid recording time, for example: work start at 9:00, then the valid time  period 7:00-11:00, to be valid between 9:00-11:00. Invalid attendance time before 7:00 or later than 11:00";
 								 
 								 default:									 
									 return "Allows the earliest and the latest valid recording time, for example: work start at 9:00, then the valid time  period 7:00-11:00, to be valid between 9:00-11:00. Invalid attendance time before 7:00 or later than 11:00";
							} 
 					}
				}


				 ///<summary>基本設置</summary>
				public static string SHIFT_BASIC_INFO_SETTING
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "基本设置";
								 case "zh-HK":
									 return "基本設置";
								  case "en-US":
									 return "Basic Setting";
 								 
 								 default:									 
									 return "Basic Setting";
							} 
 					}
				}


				 ///<summary>全局設置應用于余下其他功能</summary>
				public static string SHIFT_BASIC_INFO_SETTING_HeaderDesc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "全局设置应用于余下其他功能";
								 case "zh-HK":
									 return "全局設置應用于余下其他功能";
								  case "en-US":
									 return "Global setting is applied to other function.";
 								 
 								 default:									 
									 return "Global setting is applied to other function.";
							} 
 					}
				}


				 ///<summary>休息時間</summary>
				public static string Shift_BreakTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "休息时间";
								 case "zh-HK":
									 return "休息時間";
								  case "en-US":
									 return "Break Time";
 								 
 								 default:									 
									 return "Break Time";
							} 
 					}
				}


				 ///<summary>公司名稱</summary>
				public static string Shift_CompanyName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司名称";
								 case "zh-HK":
									 return "公司名稱";
								  case "en-US":
									 return "Company Name";
 								 
 								 default:									 
									 return "Company Name";
							} 
 					}
				}


				 ///<summary>考勤設置</summary>
				public static string Shift_DayShiftLabel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤设置";
								 case "zh-HK":
									 return "考勤設置";
								  case "en-US":
									 return "Day Shift";
 								 
 								 default:									 
									 return "Day Shift";
							} 
 					}
				}


				 ///<summary>部門</summary>
				public static string Shift_DepartmentIdArr
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部門";
								 case "zh-HK":
									 return "部門";
								  case "en-US":
									 return "Departments";
 								 
 								 default:									 
									 return "Departments";
							} 
 					}
				}


				 ///<summary>無排班 ID</summary>
				public static string SHIFT_ERROR_NO_SHIFT_ID_OR_NULL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "无排班 ID";
								 case "zh-HK":
									 return "無排班 ID";
								  case "en-US":
									 return "ERROR,No Shift ID";
 								 
 								 default:									 
									 return "ERROR,No Shift ID";
							} 
 					}
				}


				 ///<summary>例外情況</summary>
				public static string SHIFT_EXCEPTION_INFO_SETTING
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "例外情况";
								 case "zh-HK":
									 return "例外情況";
								  case "en-US":
									 return "EXCEPTION";
 								 
 								 default:									 
									 return "EXCEPTION";
							} 
 					}
				}


				 ///<summary>設置特殊案例發生時，排除或者包含計算</summary>
				public static string SHIFT_EXCEPTION_INFO_SETTING_DESC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "?置特殊案例?生?，排除或者包含?算";
								 case "zh-HK":
									 return "設置特殊案例發生時，排除或者包含計算";
								  case "en-US":
									 return "Setting for special case occured,exclude or include to calc.";
 								 
 								 default:									 
									 return "Setting for special case occured,exclude or include to calc.";
							} 
 					}
				}


				 ///<summary>加班排除</summary>
				public static string Shift_ExcludeOverTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班排除";
								 case "zh-HK":
									 return "加班排除";
								  case "en-US":
									 return "Exclude OverTime";
 								 
 								 default:									 
									 return "Exclude OverTime";
							} 
 					}
				}


				 ///<summary>在加班周期里排除，例如設置每天晚上20:00-22:00開始加班，但星期六排除這個設置邏輯。</summary>
				public static string Shift_ExcludeOverTime_Desc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "在加班周期里排除，例如设置每天晚上20:00-22:00开始加班，但星期六排除这个设置逻辑。";
								 case "zh-HK":
									 return "在加班周期里排除，例如設置每天晚上20:00-22:00開始加班，但星期六排除這個設置邏輯。";
								  case "en-US":
									 return "Exclude OverTime,e.g.,overtime at 20:00-22:00 every night,but exclude Saturday evenning.";
 								 
 								 default:									 
									 return "Exclude OverTime,e.g.,overtime at 20:00-22:00 every night,but exclude Saturday evenning.";
							} 
 					}
				}


				 ///<summary>每星期除外</summary>
				public static string Shift_ExcludeWeekDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每星期除外";
								 case "zh-HK":
									 return "每星期除外";
								  case "en-US":
									 return "Except Every Week";
 								 
 								 default:									 
									 return "Except Every Week";
							} 
 					}
				}


				 ///<summary>每星期除外（星期天可以在公眾假期設置，也可以在這里設置除外）</summary>
				public static string Shift_ExcludeWeekDayTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每星期除外（星期天可以在公众假期设置，也可以在这里设置除外）";
								 case "zh-HK":
									 return "每星期除外（星期天可以在公眾假期設置，也可以在這里設置除外）";
								  case "en-US":
									 return "Except Every Week (Sunday can be set on public holidays, and can be set here)";
 								 
 								 default:									 
									 return "Except Every Week (Sunday can be set on public holidays, and can be set here)";
							} 
 					}
				}


				 ///<summary>豁免考勤</summary>
				public static string Shift_ExemptFromAttendance
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "豁免考勤";
								 case "zh-HK":
									 return "豁免考勤";
								  case "en-US":
									 return "Exempt from attendance";
 								 
 								 default:									 
									 return "Exempt from attendance";
							} 
 					}
				}


				 ///<summary>圖標顏色</summary>
				public static string Shift_IconColor
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "图标颜色";
								 case "zh-HK":
									 return "圖標顏色";
								  case "en-US":
									 return "Icon Color";
 								 
 								 default:									 
									 return "Icon Color";
							} 
 					}
				}


				 ///<summary>審核</summary>
				public static string Shift_IsApproved
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "审核";
								 case "zh-HK":
									 return "審核";
								  case "en-US":
									 return "Audit";
 								 
 								 default:									 
									 return "Audit";
							} 
 					}
				}


				 ///<summary>漏打-允許自動計算</summary>
				public static string Shift_IsAutoCalcMissing
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "漏打-允许自动计算";
								 case "zh-HK":
									 return "漏打-允許自動計算";
								  case "en-US":
									 return "Auto Calc Missing";
 								 
 								 default:									 
									 return "Auto Calc Missing";
							} 
 					}
				}


				 ///<summary>午/晚餐自動算</summary>
				public static string Shift_IsMissingLunchTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午/晚餐自动算";
								 case "zh-HK":
									 return "午/晚餐自動算";
								  case "en-US":
									 return "Missing Lunch/MidNight Auto Calc";
 								 
 								 default:									 
									 return "Missing Lunch/MidNight Auto Calc";
							} 
 					}
				}


				 ///<summary>加班自動算</summary>
				public static string Shift_IsMissingOverTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班自动算";
								 case "zh-HK":
									 return "加班自動算";
								  case "en-US":
									 return "OverTime Auto Calc";
 								 
 								 default:									 
									 return "OverTime Auto Calc";
							} 
 					}
				}


				 ///<summary>上下班自動算</summary>
				public static string Shift_IsMissingWork
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上下班自动算";
								 case "zh-HK":
									 return "上下班自動算";
								  case "en-US":
									 return "Missing Work Auto Calc";
 								 
 								 default:									 
									 return "Missing Work Auto Calc";
							} 
 					}
				}


				 ///<summary>午餐時段</summary>
				public static string Shift_LunchTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐时段";
								 case "zh-HK":
									 return "午餐時段";
								  case "en-US":
									 return "Lunch Time";
 								 
 								 default:									 
									 return "Lunch Time";
							} 
 					}
				}


				 ///<summary>午餐時間</summary>
				public static string Shift_LunchTime_Lbl
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐时间";
								 case "zh-HK":
									 return "午餐時間";
								  case "en-US":
									 return "Lunch Time";
 								 
 								 default:									 
									 return "Lunch Time";
							} 
 					}
				}


				 ///<summary>午餐有效考勤時間</summary>
				public static string Shift_LunchTimeBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐有效考勤时间";
								 case "zh-HK":
									 return "午餐有效考勤時間";
								  case "en-US":
									 return "Lunch valid attendance time";
 								 
 								 default:									 
									 return "Lunch valid attendance time";
							} 
 					}
				}


				 ///<summary>午餐時間12：00-13：00，緩沖區為1小時，最早和最晚有效錄制時間，例如，有效范圍為11：00-14：00。</summary>
				public static string Shift_LunchTimeBufferTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐时间12：00-13：00，缓冲区为1小时，最早和最晚有效录制时间，例如，有效范围为11：00-14：00。";
								 case "zh-HK":
									 return "午餐時間12：00-13：00，緩沖區為1小時，最早和最晚有效錄制時間，例如，有效范圍為11：00-14：00。";
								  case "en-US":
									 return "LunchTime 12:00-13:00,Buffer is 1hour, the earliest and the latest valid recording time, such as , to be valid range at 11:00-14:00.";
 								 
 								 default:									 
									 return "LunchTime 12:00-13:00,Buffer is 1hour, the earliest and the latest valid recording time, such as , to be valid range at 11:00-14:00.";
							} 
 					}
				}


				 ///<summary>午餐有效結束考勤時間</summary>
				public static string Shift_LunchTimeEndBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐有效结束考勤时间";
								 case "zh-HK":
									 return "午餐有效結束考勤時間";
								  case "en-US":
									 return "Lunch effectively ends attendance time";
 								 
 								 default:									 
									 return "Lunch effectively ends attendance time";
							} 
 					}
				}


				 ///<summary>午餐時間段</summary>
				public static string Shift_LunchTimeLabel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐时间段";
								 case "zh-HK":
									 return "午餐時間段";
								  case "en-US":
									 return "LunchTime";
 								 
 								 default:									 
									 return "LunchTime";
							} 
 					}
				}


				 ///<summary>設置工作期間的吃飯時間</summary>
				public static string Shift_LunchTimeLabel_Desc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置工作期间的吃饭时间";
								 case "zh-HK":
									 return "設置工作期間的吃飯時間";
								  case "en-US":
									 return "Setting for lunch time(middle section time)";
 								 
 								 default:									 
									 return "Setting for lunch time(middle section time)";
							} 
 					}
				}


				 ///<summary>午餐有效開始考勤時間</summary>
				public static string Shift_LunchTimeStartBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐有效开始考勤时间";
								 case "zh-HK":
									 return "午餐有效開始考勤時間";
								  case "en-US":
									 return "Lunch effectively start attendance time";
 								 
 								 default:									 
									 return "Lunch effectively start attendance time";
							} 
 					}
				}


				 ///<summary>午餐時間考勤，同樣適用於晚間時段（宵夜）。</summary>
				public static string Shift_LunchTimeTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐时间考勤，同样适用於晚间时段（宵夜）。";
								 case "zh-HK":
									 return "午餐時間考勤，同樣適用於晚間時段（宵夜）。";
								  case "en-US":
									 return "Lunch Time Setting is also applied to Night Shift（Midnight meal）.";
 								 
 								 default:									 
									 return "Lunch Time Setting is also applied to Night Shift（Midnight meal）.";
							} 
 					}
				}


				 ///<summary>Main Com Id</summary>
				public static string Shift_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Main Com Id";
								 case "zh-HK":
									 return "Main Com Id";
								  case "en-US":
									 return "Main Com Id";
 								 
 								 default:									 
									 return "Main Com Id";
							} 
 					}
				}


				 ///<summary>漏打情況</summary>
				public static string SHIFT_MISSING_SETTING
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "漏打情况";
								 case "zh-HK":
									 return "漏打情況";
								  case "en-US":
									 return "MISSING";
 								 
 								 default:									 
									 return "MISSING";
							} 
 					}
				}


				 ///<summary>設置漏打發生，如何處理</summary>
				public static string SHIFT_MISSING_SETTING_DESC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置漏打发生，如何处理";
								 case "zh-HK":
									 return "設置漏打發生，如何處理";
								  case "en-US":
									 return "setting for missing occured";
 								 
 								 default:									 
									 return "setting for missing occured";
							} 
 					}
				}


				 ///<summary>考勤設置</summary>
				public static string Shift_Name
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤设置";
								 case "zh-HK":
									 return "考勤設置";
								  case "en-US":
									 return "Shift Name";
 								 
 								 default:									 
									 return "Shift Name";
							} 
 					}
				}


				 ///<summary>夜間考勤</summary>
				public static string Shift_NightSettingLabel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "夜间考勤";
								 case "zh-HK":
									 return "夜間考勤";
								  case "en-US":
									 return "Night Setting";
 								 
 								 default:									 
									 return "Night Setting";
							} 
 					}
				}


				 ///<summary>加班考勤时段</summary>
				public static string Shift_OverTimeBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班考勤时段";
								 case "zh-HK":
									 return "加班考勤时段";
								  case "en-US":
									 return "OverTime Buffer";
 								 
 								 default:									 
									 return "OverTime Buffer";
							} 
 					}
				}


				 ///<summary>加班考勤時段：分為開始的考勤時段和加班結束的考勤時段，在這期間考勤視為加班考勤，不在此時間段內的加班考勤視為，無效的考勤時段。例如：19:00加班開始，設置有效的考勤時段是60分鐘，則18:01-20:00內發生的最早的考勤記錄視為加班考勤的開始記錄。結束加班的考勤時段同理。</summary>
				public static string Shift_OverTimeBufferTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班考勤时段：分为开始的考勤时段和加班结束的考勤时段，在这期间考勤视为加班考勤，不在此时间段内的加班考勤视为，无效的考勤时段。例如：19:00加班开始，设置有效的考勤时段是60分钟，则18:01-20:00内发生的最早的考勤记录视为加班考勤的开始记录。结束加班的考勤时段同理。 ";
								 case "zh-HK":
									 return "加班考勤時段：分為開始的考勤時段和加班結束的考勤時段，在這期間考勤視為加班考勤，不在此時間段內的加班考勤視為，無效的考勤時段。例如：19:00加班開始，設置有效的考勤時段是60分鐘，則18:01-20:00內發生的最早的考勤記錄視為加班考勤的開始記錄。結束加班的考勤時段同理。";
								  case "en-US":
									 return "Overtime attendance period: It is divided into the start attendance period and the overtime attendance period. During this period, attendance is considered as overtime attendance, and overtime attendance outside this period is considered as invalid attendance period. For example: 19:00  OvertimeStart, and the valid attendance period is 60 minutes, then the earliest attendance record that occurred between 18: 01-20: 00 is considered as the start record of overtime attendance. The same principle goes for the OvertimeEnd attendance period.";
 								 
 								 default:									 
									 return "Overtime attendance period: It is divided into the start attendance period and the overtime attendance period. During this period, attendance is considered as overtime attendance, and overtime attendance outside this period is considered as invalid attendance period. For example: 19:00  OvertimeStart, and the valid attendance period is 60 minutes, then the earliest attendance record that occurred between 18: 01-20: 00 is considered as the start record of overtime attendance. The same principle goes for the OvertimeEnd attendance period.";
							} 
 					}
				}


				 ///<summary>加班結束考勤時段</summary>
				public static string Shift_OverTimeEndBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班结束考勤时段";
								 case "zh-HK":
									 return "加班結束考勤時段";
								  case "en-US":
									 return "OverTime End Buffer Duration";
 								 
 								 default:									 
									 return "OverTime End Buffer Duration";
							} 
 					}
				}


				 ///<summary>加班設置</summary>
				public static string Shift_OverTimeLabel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班设置";
								 case "zh-HK":
									 return "加班設置";
								  case "en-US":
									 return "OverTime";
 								 
 								 default:									 
									 return "OverTime";
							} 
 					}
				}


				 ///<summary>設置工作起始結束后的加班時間</summary>
				public static string Shift_OverTimeLabel_Desc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置工作起始结束后的加班时间";
								 case "zh-HK":
									 return "設置工作起始結束后的加班時間";
								  case "en-US":
									 return "Setting For Start or End of the Overtime";
 								 
 								 default:									 
									 return "Setting For Start or End of the Overtime";
							} 
 					}
				}


				 ///<summary>加班考勤有效時段</summary>
				public static string Shift_OverTimeStartBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班考勤有效时段";
								 case "zh-HK":
									 return "加班考勤有效時段";
								  case "en-US":
									 return "OverTime Start Buffer";
 								 
 								 default:									 
									 return "OverTime Start Buffer";
							} 
 					}
				}


				 ///<summary>設置加班時間</summary>
				public static string Shift_OverTimeStartEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置加班时间";
								 case "zh-HK":
									 return "設置加班時間";
								  case "en-US":
									 return "Overtime";
 								 
 								 default:									 
									 return "Overtime";
							} 
 					}
				}


				 ///<summary>設置加班起始與結束的時間</summary>
				public static string Shift_OverTimeStartEndTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置加班起始与结束的时间";
								 case "zh-HK":
									 return "設置加班起始與結束的時間";
								  case "en-US":
									 return "Set the start and end time of overtime";
 								 
 								 default:									 
									 return "Set the start and end time of overtime";
							} 
 					}
				}


				 ///<summary>返回更新成功</summary>
				public static string Shift_Return_Update_Success
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "返回更新成功";
								 case "zh-HK":
									 return "返回更新成功";
								  case "en-US":
									 return "Update Success";
 								 
 								 default:									 
									 return "Update Success";
							} 
 					}
				}


				 ///<summary>返回成功</summary>
				public static string Shift_ReturnSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "返回成功";
								 case "zh-HK":
									 return "返回成功";
								  case "en-US":
									 return "Success";
 								 
 								 default:									 
									 return "Success";
							} 
 					}
				}


				 ///<summary>排班規則說明</summary>
				public static string Shift_RuleDescription
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班规则说明";
								 case "zh-HK":
									 return "排班規則說明";
								  case "en-US":
									 return "Rule Descriptions";
 								 
 								 default:									 
									 return "Rule Descriptions";
							} 
 					}
				}


				 ///<summary>按星期定義上下班時間，例如星期六：9:00-13:00，星期天屬於公眾假期的情況下，已被假日設置排除，無需勾選。</summary>
				public static string Shift_Shift_SpecialWeekDaysTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "按星期特定上下班时间，例如星期六：9:00-13:00，星期天属于公众假期的情况下，已被假日设置排除，无需勾选。";
								 case "zh-HK":
									 return "按星期定義上下班時間，例如星期六：9:00-13:00，星期天屬於公眾假期的情況下，已被假日設置排除，無需勾選。";
								  case "en-US":
									 return "Special weekday work time definition，e.g. SAT : 9:00-13:00。SunDay is belong to StatutoryHoliday,so it needn't select.";
 								 
 								 default:									 
									 return "Special weekday work time definition，e.g. SAT : 9:00-13:00。SunDay is belong to StatutoryHoliday,so it needn't select.";
							} 
 					}
				}


				 ///<summary>縮寫ID</summary>
				public static string Shift_ShiftAbbrId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "缩写ID";
								 case "zh-HK":
									 return "縮寫ID";
								  case "en-US":
									 return "AbbrID.";
 								 
 								 default:									 
									 return "AbbrID.";
							} 
 					}
				}


				 ///<summary>縮寫ID是必須的，2個漢字內或最多4個大寫字母或4個小寫字母或4個數字，不允許混合以上條件。</summary>
				public static string Shift_ShiftAbbrId_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "缩写ID是必须的，2个汉字内或最多4个大写字母或4个小写字母或4个数字，不允许混合以上条件。";
								 case "zh-HK":
									 return "縮寫ID是必須的，2個漢字內或最多4個大寫字母或4個小寫字母或4個數字，不允許混合以上條件。";
								  case "en-US":
									 return "The abbreviation ID is required to improve the readability of the report(2 Chinese  or up to 4 uppercase letters or up to 4 lower case letter),refused to complex.";
 								 
 								 default:									 
									 return "The abbreviation ID is required to improve the readability of the report(2 Chinese  or up to 4 uppercase letters or up to 4 lower case letter),refused to complex.";
							} 
 					}
				}


				 ///<summary>應用模式</summary>
				public static string Shift_ShiftAppliedMode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "应用模式";
								 case "zh-HK":
									 return "應用模式";
								  case "en-US":
									 return "Applied Mode";
 								 
 								 default:									 
									 return "Applied Mode";
							} 
 					}
				}


				 ///<summary>業務模式</summary>
				public static string Shift_ShiftBusinessMode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "业务模式";
								 case "zh-HK":
									 return "業務模式";
								  case "en-US":
									 return "Shift Business Mode";
 								 
 								 default:									 
									 return "Shift Business Mode";
							} 
 					}
				}


				 ///<summary>排班安排失敗</summary>
				public static string Shift_ShiftDepartmentAsigned_Fail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班安排失败";
								 case "zh-HK":
									 return "排班安排失敗";
								  case "en-US":
									 return "Shift Roster Fail!";
 								 
 								 default:									 
									 return "Shift Roster Fail!";
							} 
 					}
				}


				 ///<summary>請稍等，部門人數太多（>10），以交給系統作業任務處理，請稍等幾分鐘再查閱結果！</summary>
				public static string Shift_ShiftDepartmentAsigned_OverLoad
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请稍等，部门人数太多（>10），以交给系统作业任务处理，请稍等几分钟再查阅结果！";
								 case "zh-HK":
									 return "請稍等，部門人數太多（>10），以交給系統作業任務處理，請稍等幾分鐘再查閱結果！";
								  case "en-US":
									 return "Please wait...,as more than 10 peaple,this current task has tansfer to backend as a Job.";
 								 
 								 default:									 
									 return "Please wait...,as more than 10 peaple,this current task has tansfer to backend as a Job.";
							} 
 					}
				}


				 ///<summary>部門排班安排成功</summary>
				public static string Shift_ShiftDepartmentAsigned_Result
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "部门排班安排成功";
								 case "zh-HK":
									 return "部門排班安排成功";
								  case "en-US":
									 return "Department Shift Roaster Success!";
 								 
 								 default:									 
									 return "Department Shift Roaster Success!";
							} 
 					}
				}


				 ///<summary>ID</summary>
				public static string Shift_ShiftId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "ID";
								 case "zh-HK":
									 return "ID";
								  case "en-US":
									 return "Shift Id";
 								 
 								 default:									 
									 return "Shift Id";
							} 
 					}
				}


				 ///<summary>沒有存在后續，可以修改</summary>
				public static string Shift_ShiftInScheduleRejectToModified_False
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有存在后续，可以修改";
								 case "zh-HK":
									 return "沒有存在后續，可以修改";
								  case "en-US":
									 return "No Following Schedule，It is allowed to modify";
 								 
 								 default:									 
									 return "No Following Schedule，It is allowed to modify";
							} 
 					}
				}


				 ///<summary>后續排班存在，禁止修改</summary>
				public static string Shift_ShiftInScheduleRejectToModified_True
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "后续排班存在，禁止修改";
								 case "zh-HK":
									 return "后續排班存在，禁止修改";
								  case "en-US":
									 return "Exist Following Schedule，It is rejected to modify";
 								 
 								 default:									 
									 return "Exist Following Schedule，It is rejected to modify";
							} 
 					}
				}


				 ///<summary>當前考勤沒有獲得審批</summary>
				public static string Shift_ShiftIsApproved_False
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当前考勤没有获得审批";
								 case "zh-HK":
									 return "當前考勤沒有獲得審批";
								  case "en-US":
									 return "ShiftIs is not approved.";
 								 
 								 default:									 
									 return "ShiftIs is not approved.";
							} 
 					}
				}


				 ///<summary>當前考勤已被獲得審批</summary>
				public static string Shift_ShiftIsApproved_True
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "当前考勤已被获得审批";
								 case "zh-HK":
									 return "當前考勤已被獲得審批";
								  case "en-US":
									 return "ShiftIs is Approved";
 								 
 								 default:									 
									 return "ShiftIs is Approved";
							} 
 					}
				}


				 ///<summary>考勤設置名稱</summary>
				public static string Shift_ShiftName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤设置名称";
								 case "zh-HK":
									 return "考勤設置名稱";
								  case "en-US":
									 return "Shift Name";
 								 
 								 default:									 
									 return "Shift Name";
							} 
 					}
				}


				 ///<summary>請輸入排班名稱</summary>
				public static string Shift_ShiftName_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入排班名称";
								 case "zh-HK":
									 return "請輸入排班名稱";
								  case "en-US":
									 return "Please input valid shift name";
 								 
 								 default:									 
									 return "Please input valid shift name";
							} 
 					}
				}


				 ///<summary>設置小息時段</summary>
				public static string Shift_ShiftSettingBreak
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置小息时段";
								 case "zh-HK":
									 return "設置小息時段";
								  case "en-US":
									 return "Set Breaktime";
 								 
 								 default:									 
									 return "Set Breaktime";
							} 
 					}
				}


				 ///<summary>設置午餐時段</summary>
				public static string Shift_ShiftSettingLunch
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "設置午餐時段";
								 case "zh-HK":
									 return "設置午餐時段";
								  case "en-US":
									 return "Set LunchTime";
 								 
 								 default:									 
									 return "Set LunchTime";
							} 
 					}
				}


				 ///<summary>Turn to 夜更设置</summary>
				public static string Shift_ShiftSettingNight
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Turn to 夜更设置";
								 case "zh-HK":
									 return "Turn to 夜更设置";
								  case "en-US":
									 return "Turn to NightShift";
 								 
 								 default:									 
									 return "Turn to NightShift";
							} 
 					}
				}


				 ///<summary>Turn to 加班OT Shift</summary>
				public static string Shift_ShiftSettingOverTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Turn to 加班OT Shift";
								 case "zh-HK":
									 return "Turn to 加班OT Shift";
								  case "en-US":
									 return "Turn to OverTimeShift";
 								 
 								 default:									 
									 return "Turn to OverTimeShift";
							} 
 					}
				}


				 ///<summary>Turn to 按星期设更</summary>
				public static string Shift_ShiftSettingWeekDay
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Turn to 按星期设更";
								 case "zh-HK":
									 return "Turn to 按星期设更";
								  case "en-US":
									 return "Turn to WeekdayShift";
 								 
 								 default:									 
									 return "Turn to WeekdayShift";
							} 
 					}
				}


				 ///<summary>通用計算（Day）</summary>
				public static string Shift_SimpleCalc
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "通用计算（Day）";
								 case "zh-HK":
									 return "通用計算（Day）";
								  case "en-US":
									 return "General Calc（Day Shift）";
 								 
 								 default:									 
									 return "General Calc（Day Shift）";
							} 
 					}
				}


				 ///<summary>每星期特別工作日</summary>
				public static string Shift_SpecialWeekDays
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每星期特别工作日";
								 case "zh-HK":
									 return "每星期特別工作日";
								  case "en-US":
									 return "Special Week Days";
 								 
 								 default:									 
									 return "Special Week Days";
							} 
 					}
				}


				 ///<summary>指定星期的工作時間</summary>
				public static string Shift_SpecialWeekDays_WorkTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "指定星期的工作时间";
								 case "zh-HK":
									 return "指定星期的工作時間";
								  case "en-US":
									 return "WorkTime Of Special WeekDay";
 								 
 								 default:									 
									 return "WorkTime Of Special WeekDay";
							} 
 					}
				}


				 ///<summary>指定日下班時間</summary>
				public static string Shift_SpecialWeekDaysWorkEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "指定日下班时间";
								 case "zh-HK":
									 return "指定日下班時間";
								  case "en-US":
									 return "Special WeekDay WorkEnd";
 								 
 								 default:									 
									 return "Special WeekDay WorkEnd";
							} 
 					}
				}


				 ///<summary>指定日上班時間</summary>
				public static string Shift_SpecialWeekDaysWorkStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "指定日上班时间";
								 case "zh-HK":
									 return "指定日上班時間";
								  case "en-US":
									 return "Special WeekDay WorkStart";
 								 
 								 default:									 
									 return "Special WeekDay WorkStart";
							} 
 					}
				}


				 ///<summary>每周設置</summary>
				public static string Shift_WeekDaySettingLabel
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每周设置";
								 case "zh-HK":
									 return "每周設置";
								  case "en-US":
									 return "WeekDay Setting";
 								 
 								 default:									 
									 return "WeekDay Setting";
							} 
 					}
				}


				 ///<summary>工作時間</summary>
				public static string SHIFT_WORK_TIME_SETTING
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作时间";
								 case "zh-HK":
									 return "工作時間";
								  case "en-US":
									 return "WORK TIME";
 								 
 								 default:									 
									 return "WORK TIME";
							} 
 					}
				}


				 ///<summary>設置工作起始結束時間</summary>
				public static string SHIFT_WORK_TIME_SETTING_DESC
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "设置工作起始结束时间";
								 case "zh-HK":
									 return "設置工作起始結束時間";
								  case "en-US":
									 return "SHIFT_WORK_TIME_SETTING_DESC";
 								 
 								 default:									 
									 return "SHIFT_WORK_TIME_SETTING_DESC";
							} 
 					}
				}


				 ///<summary>下班時間</summary>
				public static string Shift_WorkEnd
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班时间";
								 case "zh-HK":
									 return "下班時間";
								  case "en-US":
									 return "Work End";
 								 
 								 default:									 
									 return "Work End";
							} 
 					}
				}


				 ///<summary>請輸入工作結束時間</summary>
				public static string Shift_WorkEnd_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入工作结束时间";
								 case "zh-HK":
									 return "請輸入工作結束時間";
								  case "en-US":
									 return "Please input valid work end ,required.";
 								 
 								 default:									 
									 return "Please input valid work end ,required.";
							} 
 					}
				}


				 ///<summary>工作结束的寬限時間</summary>
				public static string Shift_WorkEndAllowance
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作结束的宽限时间";
								 case "zh-HK":
									 return "工作结束的寬限時間";
								  case "en-US":
									 return "Work End Allowance";
 								 
 								 default:									 
									 return "Work End Allowance";
							} 
 					}
				}


				 ///<summary>請輸入工作結束的寬限時間</summary>
				public static string Shift_WorkEndAllowance_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入工作结束的宽限时间";
								 case "zh-HK":
									 return "請輸入工作結束的寬限時間";
								  case "en-US":
									 return "Please input work end allowance.";
 								 
 								 default:									 
									 return "Please input work end allowance.";
							} 
 					}
				}


				 ///<summary>下班考勤允許時間范圍</summary>
				public static string Shift_WorkEndBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "下班考勤允许时间范围";
								 case "zh-HK":
									 return "下班考勤允許時間范圍";
								  case "en-US":
									 return "Work End Buffer";
 								 
 								 default:									 
									 return "Work End Buffer";
							} 
 					}
				}


				 ///<summary>請輸入有效考勤結束時間</summary>
				public static string Shift_WorkEndBuffer_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效考勤结束时间";
								 case "zh-HK":
									 return "請輸入有效考勤結束時間";
								  case "en-US":
									 return "Please input work start buffer.";
 								 
 								 default:									 
									 return "Please input work start buffer.";
							} 
 					}
				}


				 ///<summary>上班時間</summary>
				public static string Shift_WorkStart
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班时间";
								 case "zh-HK":
									 return "上班時間";
								  case "en-US":
									 return "Work Start";
 								 
 								 default:									 
									 return "Work Start";
							} 
 					}
				}


				 ///<summary>請輸入工作開始時間</summary>
				public static string Shift_WorkStart_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入工作开始时间";
								 case "zh-HK":
									 return "請輸入工作開始時間";
								  case "en-US":
									 return "Please input valid work start ,required.";
 								 
 								 default:									 
									 return "Please input valid work start ,required.";
							} 
 					}
				}


				 ///<summary>工作开始的宽限时间</summary>
				public static string Shift_WorkStartAllowance
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作开始的宽限时间";
								 case "zh-HK":
									 return "工作开始的宽限时间";
								  case "en-US":
									 return "Work Start Allowance";
 								 
 								 default:									 
									 return "Work Start Allowance";
							} 
 					}
				}


				 ///<summary>請輸入工作開始的寬限時間</summary>
				public static string Shift_WorkStartAllowance_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入工作开始的宽限时间";
								 case "zh-HK":
									 return "請輸入工作開始的寬限時間";
								  case "en-US":
									 return "Please input work start allowance.";
 								 
 								 default:									 
									 return "Please input work start allowance.";
							} 
 					}
				}


				 ///<summary>工作開始的寬限時間</summary>
				public static string Shift_WorkStartBuffer
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上班考勤允许时间范围";
								 case "zh-HK":
									 return "工作開始的寬限時間";
								  case "en-US":
									 return "Work Start Buffer";
 								 
 								 default:									 
									 return "Work Start Buffer";
							} 
 					}
				}


				 ///<summary>請輸入有效開始考勤時間</summary>
				public static string Shift_WorkStartBuffer_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请输入有效开始考勤时间";
								 case "zh-HK":
									 return "請輸入有效開始考勤時間";
								  case "en-US":
									 return "Please input work start buffer.";
 								 
 								 default:									 
									 return "Please input work start buffer.";
							} 
 					}
				}


				 ///<summary>工作時間設置</summary>
				public static string Shift_WorkTimeSpan
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "工作时间设置";
								 case "zh-HK":
									 return "工作時間設置";
								  case "en-US":
									 return "Work Time";
 								 
 								 default:									 
									 return "Work Time";
							} 
 					}
				}


				 ///<summary>全局模式</summary>
				public static string ShiftAppliedMode_GLOBAL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "全局模式";
								 case "zh-HK":
									 return "全局模式";
								  case "en-US":
									 return "GLOBAL";
 								 
 								 default:									 
									 return "GLOBAL";
							} 
 					}
				}


				 ///<summary>自定义模式(DEF)</summary>
				public static string ShiftAppliedMode_PARTIAL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自定义模式(DEF)";
								 case "zh-HK":
									 return "自定义模式(DEF)";
								  case "en-US":
									 return "PARTIAL(DEF)";
 								 
 								 default:									 
									 return "PARTIAL(DEF)";
							} 
 					}
				}


				 ///<summary>手動指派</summary>
				public static string ShiftAssignedMode_MANUAL_ASSIGNED
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "手动指派";
								 case "zh-HK":
									 return "手動指派";
								  case "en-US":
									 return "MANUAL ASSIGNED";
 								 
 								 default:									 
									 return "MANUAL ASSIGNED";
							} 
 					}
				}


				 ///<summary>系統指派</summary>
				public static string ShiftAssignedMode_SYSTEM_ASSIGNED
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统指派";
								 case "zh-HK":
									 return "系統指派";
								  case "en-US":
									 return "SYSTEM ASSIGNED";
 								 
 								 default:									 
									 return "SYSTEM ASSIGNED";
							} 
 					}
				}


				 ///<summary>排班考勤簡報</summary>
				public static string ShiftBrief_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班考勤简报";
								 case "zh-HK":
									 return "排班考勤簡報";
								  case "en-US":
									 return "The shifts of briefing";
 								 
 								 default:									 
									 return "The shifts of briefing";
							} 
 					}
				}


				 ///<summary>跨日計算模式</summary>
				public static string ShiftBusinessMode_CROSSDAYSSHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "跨日计算模式";
								 case "zh-HK":
									 return "跨日計算模式";
								  case "en-US":
									 return "CROSS DAY STHIFT";
 								 
 								 default:									 
									 return "CROSS DAY STHIFT";
							} 
 					}
				}


				 ///<summary>日班計算模式</summary>
				public static string ShiftBusinessMode_DAY_SHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日班计算模式";
								 case "zh-HK":
									 return "日班計算模式";
								  case "en-US":
									 return "DAY SHIFT";
 								 
 								 default:									 
									 return "DAY SHIFT";
							} 
 					}
				}


				 ///<summary>日更計算模式</summary>
				public static string ShiftBusinessMode_DAYSHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "日班计算模式";
								 case "zh-HK":
									 return "日更計算模式";
								  case "en-US":
									 return "DAY THIFT";
 								 
 								 default:									 
									 return "DAY THIFT";
							} 
 					}
				}


				 ///<summary>通用更期計算模式</summary>
				public static string ShiftBusinessMode_GENERAL
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "通用更期计算模式";
								 case "zh-HK":
									 return "通用更期計算模式";
								  case "en-US":
									 return "GENERAL THIFT";
 								 
 								 default:									 
									 return "GENERAL THIFT";
							} 
 					}
				}


				 ///<summary>夜更計算模式</summary>
				public static string ShiftBusinessMode_NIGHT_SHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "夜更计算模式";
								 case "zh-HK":
									 return "夜更計算模式";
								  case "en-US":
									 return "NIGHT THIFT";
 								 
 								 default:									 
									 return "NIGHT THIFT";
							} 
 					}
				}


				 ///<summary>夜班計算模式</summary>
				public static string ShiftBusinessMode_NIGHTSHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "夜更计算模式";
								 case "zh-HK":
									 return "夜班計算模式";
								  case "en-US":
									 return "NIGHT THIFT";
 								 
 								 default:									 
									 return "NIGHT THIFT";
							} 
 					}
				}


				 ///<summary>通宵計算模式</summary>
				public static string ShiftBusinessMode_OVERNIGHTSHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "通宵计算模式";
								 case "zh-HK":
									 return "通宵計算模式";
								  case "en-US":
									 return "OVER NIGHT THIFT";
 								 
 								 default:									 
									 return "OVER NIGHT THIFT";
							} 
 					}
				}


				 ///<summary>三班制計算模式</summary>
				public static string ShiftBusinessMode_THREESHIFT
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "三班制计算模式";
								 case "zh-HK":
									 return "三班制計算模式";
								  case "en-US":
									 return "THREETHIFT";
 								 
 								 default:									 
									 return "THREETHIFT";
							} 
 					}
				}


				 ///<summary>存在後續排班安排，不能否定審核</summary>
				public static string ShiftIsApprovedConfirmed_ReturnTrueResult
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在後续排班安排，不能否定审核";
								 case "zh-HK":
									 return "存在後續排班安排，不能否定審核";
								  case "en-US":
									 return "Exist coming schedule,Shift Is approved to confirmed.";
 								 
 								 default:									 
									 return "Exist coming schedule,Shift Is approved to confirmed.";
							} 
 					}
				}


				 ///<summary>警告：考勤設置忽略假期與請假，也就是強行安排上班。</summary>
				public static string ShiftList_IgnoreHolidayAndLeave_Warming
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "警告：考勤设置忽略假期与请假，也就是强行安排上班。";
								 case "zh-HK":
									 return "警告：考勤設置忽略假期與請假，也就是強行安排上班。";
								  case "en-US":
									 return "Warming：Shift setting Igore the holiday and leave ，that will be forced to work！";
 								 
 								 default:									 
									 return "Warming：Shift setting Igore the holiday and leave ，that will be forced to work！";
							} 
 					}
				}


				 ///<summary>自動（GLOBAL）:系統每月自動按照考勤設置排班，直至終止日期為止。自定義（PARTIAL）:指的是人為手動排班，直至設置日期為止。</summary>
				public static string Shiftlist_ShiftAppliedModeDescription
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "自动（GLOBAL）:系统每月自动按照考勤设置排班，直至终止日期为止。自定义（PARTIAL）:指的是人为手动排班，直至设置日期为止。";
								 case "zh-HK":
									 return "自動（GLOBAL）:系統每月自動按照考勤設置排班，直至終止日期為止。自定義（PARTIAL）:指的是人為手動排班，直至設置日期為止。";
								  case "en-US":
									 return "Automatic (GLOBAL): The system automatically schedules the shift according to the shift setting every month until the end date. PARTIAL: Refers to manual  scheduling the shift until the end date.";
 								 
 								 default:									 
									 return "Automatic (GLOBAL): The system automatically schedules the shift according to the shift setting every month until the end date. PARTIAL: Refers to manual  scheduling the shift until the end date.";
							} 
 					}
				}


				 ///<summary>加班排班考勤簡報</summary>
				public static string ShiftOverTimeBrief_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班排班考勤简报";
								 case "zh-HK":
									 return "加班排班考勤簡報";
								  case "en-US":
									 return "Shift OverTime Brief";
 								 
 								 default:									 
									 return "Shift OverTime Brief";
							} 
 					}
				}


				 ///<summary>排班考勤報表</summary>
				public static string ShiftReports_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "排班考勤报表";
								 case "zh-HK":
									 return "排班考勤報表";
								  case "en-US":
									 return " Statistics Reports  By Shift";
 								 
 								 default:									 
									 return " Statistics Reports  By Shift";
							} 
 					}
				}


				 ///<summary>考勤排班设置</summary>
				public static string ShiftSetting_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤排班設置";
								 case "zh-HK":
									 return "考勤排班设置";
								  case "en-US":
									 return "Shift Setting";
 								 
 								 default:									 
									 return "Shift Setting";
							} 
 					}
				}


				 ///<summary>夜餐時間</summary>
				public static string ShiftSettingLunch_MidNightTime
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "夜餐时间";
								 case "zh-HK":
									 return "夜餐時間";
								  case "en-US":
									 return "MidNight Meal Time";
 								 
 								 default:									 
									 return "MidNight Meal Time";
							} 
 					}
				}


				 ///<summary>午餐時間考勤</summary>
				public static string ShiftSettingLunch_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "午餐时间考勤";
								 case "zh-HK":
									 return "午餐時間考勤";
								  case "en-US":
									 return "Lunch Setting";
 								 
 								 default:									 
									 return "Lunch Setting";
							} 
 					}
				}


				 ///<summary>夜班更表</summary>
				public static string ShiftSettingNight_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "夜班更表";
								 case "zh-HK":
									 return "夜班更表";
								  case "en-US":
									 return "Night Shift Setting";
 								 
 								 default:									 
									 return "Night Shift Setting";
							} 
 					}
				}


				 ///<summary>加班設置</summary>
				public static string ShiftSettingOverTime_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "加班设置";
								 case "zh-HK":
									 return "加班設置";
								  case "en-US":
									 return "OverTime Setting";
 								 
 								 default:									 
									 return "OverTime Setting";
							} 
 					}
				}


				 ///<summary>每星期考勤排除设置</summary>
				public static string ShiftSettingWeekDay_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "每星期考勤排除设置";
								 case "zh-HK":
									 return "每星期考勤排除设置";
								  case "en-US":
									 return "Special/Exclude WeekDay ShiftSetting";
 								 
 								 default:									 
									 return "Special/Exclude WeekDay ShiftSetting";
							} 
 					}
				}


				 ///<summary>忽略請假與公眾假期</summary>
				public static string ShiftSignedDepartmentView_IgnoreHolidayAndLeave
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "忽略请假与公众假期";
								 case "zh-HK":
									 return "忽略請假與公眾假期";
								  case "en-US":
									 return "Ignore holiday and leave";
 								 
 								 default:									 
									 return "Ignore holiday and leave";
							} 
 					}
				}


				 ///<summary>位置編輯</summary>
				public static string Site_EditSiteDetails_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置编辑";
								 case "zh-HK":
									 return "位置編輯";
								  case "en-US":
									 return "Edit Site Details";
 								 
 								 default:									 
									 return "Edit Site Details";
							} 
 					}
				}


				 ///<summary>公司ID</summary>
				public static string Site_MainComId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公司ID";
								 case "zh-HK":
									 return "公司ID";
								  case "en-US":
									 return "Company Id";
 								 
 								 default:									 
									 return "Company Id";
							} 
 					}
				}


				 ///<summary>位置記錄不存在</summary>
				public static string Site_NotExistRecord
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置记录不存在";
								 case "zh-HK":
									 return "位置記錄不存在";
								  case "en-US":
									 return "Site Not Exist Record";
 								 
 								 default:									 
									 return "Site Not Exist Record";
							} 
 					}
				}


				 ///<summary>新增位置</summary>
				public static string Site_SiteAddNew_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新增位置";
								 case "zh-HK":
									 return "新增位置";
								  case "en-US":
									 return "Add a new site";
 								 
 								 default:									 
									 return "Add a new site";
							} 
 					}
				}


				 ///<summary>位置地址</summary>
				public static string Site_SiteAddress
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置地址";
								 case "zh-HK":
									 return "位置地址";
								  case "en-US":
									 return "Site Address";
 								 
 								 default:									 
									 return "Site Address";
							} 
 					}
				}


				 ///<summary>e.g. 房間、工作室、分公司等位置</summary>
				public static string Site_SiteAddressTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "e.g. 房间、工作室、分公司等位置";
								 case "zh-HK":
									 return "e.g. 房間、工作室、分公司等位置";
								  case "en-US":
									 return "e.g. room,studio,sub company";
 								 
 								 default:									 
									 return "e.g. room,studio,sub company";
							} 
 					}
				}


				 ///<summary>位置ID</summary>
				public static string Site_SiteId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置ID";
								 case "zh-HK":
									 return "位置ID";
								  case "en-US":
									 return "Site Id";
 								 
 								 default:									 
									 return "Site Id";
							} 
 					}
				}


				 ///<summary>位置名稱</summary>
				public static string Site_SiteName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置名称";
								 case "zh-HK":
									 return "位置名稱";
								  case "en-US":
									 return "Site Name";
 								 
 								 default:									 
									 return "Site Name";
							} 
 					}
				}


				 ///<summary>建議2-4個字</summary>
				public static string Site_SiteNameTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "建议2-4个字";
								 case "zh-HK":
									 return "建議2-4個字";
								  case "en-US":
									 return "Suggest 2-4words";
 								 
 								 default:									 
									 return "Suggest 2-4words";
							} 
 					}
				}


				 ///<summary>好的，再考慮一下吧！</summary>
				public static string SiteList_ComfirmNoTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "好的，再考虑一下吧！";
								 case "zh-HK":
									 return "好的，再考慮一下吧！";
								  case "en-US":
									 return "OK! Let‘s think about it!";
 								 
 								 default:									 
									 return "OK! Let‘s think about it!";
							} 
 					}
				}


				 ///<summary>確定刪除當前所選位置嗎？</summary>
				public static string SiteList_ComfirmTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "确定删除当前所选位置吗？";
								 case "zh-HK":
									 return "確定刪除當前所選位置嗎？";
								  case "en-US":
									 return "確定刪除當前所選位置嗎？";
 								 
 								 default:									 
									 return "確定刪除當前所選位置嗎？";
							} 
 					}
				}


				 ///<summary>位置列表</summary>
				public static string SiteList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "位置列表";
								 case "zh-HK":
									 return "位置列表";
								  case "en-US":
									 return "Site List";
 								 
 								 default:									 
									 return "Site List";
							} 
 					}
				}


				 ///<summary>存在相同的SiteName</summary>
				public static string SiteNameAddNew_ExistTheSameSiteName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "存在相同的SiteName";
								 case "zh-HK":
									 return "存在相同的SiteName";
								  case "en-US":
									 return "Exist the same SiteName";
 								 
 								 default:									 
									 return "Exist the same SiteName";
							} 
 					}
				}


				 ///<summary>必填項，e.g. 房間、工作室、分公司等位置</summary>
				public static string SiteView_SiteAddress_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "必填项，e.g. 房间、工作室、分公司等位置";
								 case "zh-HK":
									 return "必填項，e.g. 房間、工作室、分公司等位置";
								  case "en-US":
									 return "Required, e.g. room,studio,sub company";
 								 
 								 default:									 
									 return "Required, e.g. room,studio,sub company";
							} 
 					}
				}


				 ///<summary>必填項，建議2-4字，以免影響報表排版</summary>
				public static string SiteView_SiteName_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "必填项，建议2-4字，以免影响报表排版";
								 case "zh-HK":
									 return "必填項，建議2-4字，以免影響報表排版";
								  case "en-US":
									 return "Required, Suggest 2-4 words to avoid layout messy";
 								 
 								 default:									 
									 return "Required, Suggest 2-4 words to avoid layout messy";
							} 
 					}
				}


				 ///<summary>首先選擇導入文件</summary>
				public static string StandardImport_BoxTitleSelectFirst
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "首先选择导入文件";
								 case "zh-HK":
									 return "首先選擇導入文件";
								  case "en-US":
									 return "Select excel file to import at first";
 								 
 								 default:									 
									 return "Select excel file to import at first";
							} 
 					}
				}


				 ///<summary>批量導入考勤名單</summary>
				public static string StandardImport_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "批量导入考勤名单";
								 case "zh-HK":
									 return "批量導入考勤名單";
								  case "en-US":
									 return "Batch Import Name List";
 								 
 								 default:									 
									 return "Batch Import Name List";
							} 
 					}
				}


				 ///<summary>文件類型不符（必須上存Excel文檔類型）</summary>
				public static string StandardImport_UnexpectFileType
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "文件类型不符（必须上存Excel文档类型）";
								 case "zh-HK":
									 return "文件類型不符（必須上存Excel文檔類型）";
								  case "en-US":
									 return "The file type does not match (the Excel document type must be uploaded)";
 								 
 								 default:									 
									 return "The file type does not match (the Excel document type must be uploaded)";
							} 
 					}
				}


				 ///<summary>上存考勤人員（Excel文檔類型）</summary>
				public static string StandardImport_UploadExcelFile
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "上存考勤人员（Excel文档类型）";
								 case "zh-HK":
									 return "上存考勤人員（Excel文檔類型）";
								  case "en-US":
									 return "Upload Attendance Name List  (Excel doc type required)";
 								 
 								 default:									 
									 return "Upload Attendance Name List  (Excel doc type required)";
							} 
 					}
				}


				 ///<summary>公眾假期</summary>
				public static string StatutoryHoliday_IS_STATUTORY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "公众假期";
								 case "zh-HK":
									 return "公眾假期";
								  case "en-US":
									 return "IS STATUTORY";
 								 
 								 default:									 
									 return "IS STATUTORY";
							} 
 					}
				}


				 ///<summary>非公眾假期</summary>
				public static string StatutoryHoliday_NOT_STATUTORY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "非公众假期";
								 case "zh-HK":
									 return "非公眾假期";
								  case "en-US":
									 return "NOT STATUTORY";
 								 
 								 default:									 
									 return "NOT STATUTORY";
							} 
 					}
				}


				 ///<summary>后悔了！一鍵取消所有導入！</summary>
				public static string Sychronize_List_RestoreImport
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "后悔了！一键取消所有导入！";
								 case "zh-HK":
									 return "后悔了！一鍵取消所有導入！";
								  case "en-US":
									 return "Oh!My god! Canel All imported";
 								 
 								 default:									 
									 return "Oh!My god! Canel All imported";
							} 
 					}
				}


				 ///<summary>應用所有分頁（刪除所有本年度的歷史導入）</summary>
				public static string Sychronize_List_RestoreImportForAllPageTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "应用所有分页（删除所有本年度的历史导入）";
								 case "zh-HK":
									 return "應用所有分頁（刪除所有本年度的歷史導入）";
								  case "en-US":
									 return "Applied to all(delete all in this year)";
 								 
 								 default:									 
									 return "Applied to all(delete all in this year)";
							} 
 					}
				}


				 ///<summary>考勤人員同步</summary>
				public static string SynchronizeList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤人员同步";
								 case "zh-HK":
									 return "考勤人員同步";
								  case "en-US":
									 return "Synchronize List";
 								 
 								 default:									 
									 return "Synchronize List";
							} 
 					}
				}


				 ///<summary>門禁卡號</summary>
				public static string SynchronizeMode_ACCESSCARD_ID
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "门禁卡号";
								 case "zh-HK":
									 return "門禁卡號";
								  case "en-US":
									 return "ACCESSCARD No";
 								 
 								 default:									 
									 return "ACCESSCARD No";
							} 
 					}
				}


				 ///<summary>姓名</summary>
				public static string SynchronizeMode_CNNAME
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "姓名";
								 case "zh-HK":
									 return "姓名";
								  case "en-US":
									 return "CN NAME";
 								 
 								 default:									 
									 return "CN NAME";
							} 
 					}
				}


				 ///<summary>CWRGss</summary>
				public static string SynchronizeMode_CWRG
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "CWRGss";
								 case "zh-HK":
									 return "CWRGss";
								  case "en-US":
									 return "CWRG";
 								 
 								 default:									 
									 return "CWRG";
							} 
 					}
				}


				 ///<summary>全名</summary>
				public static string SynchronizeMode_FULL_NAME
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "全名";
								 case "zh-HK":
									 return "全名";
								  case "en-US":
									 return "FULL NAME";
 								 
 								 default:									 
									 return "FULL NAME";
							} 
 					}
				}


				 ///<summary>證件號碼</summary>
				public static string SynchronizeMode_ID_NUMBER
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "证件号码";
								 case "zh-HK":
									 return "證件號碼";
								  case "en-US":
									 return "ID NUMBER";
 								 
 								 default:									 
									 return "ID NUMBER";
							} 
 					}
				}


				 ///<summary>第三方考勤ID</summary>
				public static string SynchronizeView_The3rdPartyEmployeeId
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "第三方考勤ID";
								 case "zh-HK":
									 return "第三方考勤ID";
								  case "en-US":
									 return "The3rd ID";
 								 
 								 default:									 
									 return "The3rd ID";
							} 
 					}
				}


				 ///<summary>沒有標記的數據被恢復（刪除）</summary>
				public static string SyncRestoreDelete_NoRecordToDelete
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "没有标记的数据被恢复（删除）";
								 case "zh-HK":
									 return "沒有標記的數據被恢復（刪除）";
								  case "en-US":
									 return "No feature data to restore(delete)";
 								 
 								 default:									 
									 return "No feature data to restore(delete)";
							} 
 					}
				}


				 ///<summary>成功取消當前導入的名單</summary>
				public static string SyncRestoreDelete_Success
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "成功取消当前导入的名单";
								 case "zh-HK":
									 return "成功取消當前導入的名單";
								  case "en-US":
									 return "It is successfully to canel the current imported!";
 								 
 								 default:									 
									 return "It is successfully to canel the current imported!";
							} 
 					}
				}


				 ///<summary>分配的部門已成功保存</summary>
				public static string SysBusinessSetting_ShiftDepartmentArr_Msg1
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "分配的部门已成功保存";
								 case "zh-HK":
									 return "分配的部門已成功保存";
								  case "en-US":
									 return "Assigned Department Seccessfully!";
 								 
 								 default:									 
									 return "Assigned Department Seccessfully!";
							} 
 					}
				}


				 ///<summary>請選擇最少一個部門，或者選擇第一個（所有部門）</summary>
				public static string SysBusinessSetting_ShiftDepartmentArr_Msg3
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "请选择最少一个部门，或者选择第一个（所有部门）";
								 case "zh-HK":
									 return "請選擇最少一個部門，或者選擇第一個（所有部門）";
								  case "en-US":
									 return "Please Select one department at least,or select the first(All department)";
 								 
 								 default:									 
									 return "Please Select one department at least,or select the first(All department)";
							} 
 					}
				}


				 ///<summary>模組名稱</summary>
				public static string SysModule_SysModuleName
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "模组名称";
								 case "zh-HK":
									 return "模組名稱";
								  case "en-US":
									 return "Sys Module Name";
 								 
 								 default:									 
									 return "Sys Module Name";
							} 
 					}
				}


				 ///<summary>CreatedDate</summary>
				public static string Trade_CreatedDate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "CreatedDate";
								 case "zh-HK":
									 return "CreatedDate";
								  case "en-US":
									 return "CreatedDate";
 								 
 								 default:									 
									 return "CreatedDate";
							} 
 					}
				}


				 ///<summary>Position Eng Title</summary>
				public static string Trade_EnPositionTitle
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Position Eng Title";
								 case "zh-HK":
									 return "Position Eng Title";
								  case "en-US":
									 return "Eng PositionTitle";
 								 
 								 default:									 
									 return "Eng PositionTitle";
							} 
 					}
				}


				 ///<summary>考勤人員</summary>
				public static string User_Employee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "考勤人员";
								 case "zh-HK":
									 return "考勤人員";
								  case "en-US":
									 return "Attendance";
 								 
 								 default:									 
									 return "Attendance";
							} 
 					}
				}


				 ///<summary>更新角色失敗 !</summary>
				public static string User_UserRolesAssignedUpdate_UpdateRolesFail
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "更新角色失败 !";
								 case "zh-HK":
									 return "更新角色失敗 !";
								  case "en-US":
									 return "UpdateRolesFail ！";
 								 
 								 default:									 
									 return "UpdateRolesFail ！";
							} 
 					}
				}


				 ///<summary>更新角色成功!</summary>
				public static string User_UserRolesAssignedUpdate_UpdateRolesSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "更新角色成功!";
								 case "zh-HK":
									 return "更新角色成功!";
								  case "en-US":
									 return "Update Roles Success！";
 								 
 								 default:									 
									 return "Update Roles Success！";
							} 
 					}
				}


				 ///<summary>關 聯</summary>
				public static string UserList_Associate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "关 联";
								 case "zh-HK":
									 return "關 聯";
								  case "en-US":
									 return "Associate";
 								 
 								 default:									 
									 return "Associate";
							} 
 					}
				}


				 ///<summary>取消關聯</summary>
				public static string UserList_CancelAssociate
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "取消关联";
								 case "zh-HK":
									 return "取消關聯";
								  case "en-US":
									 return "Cancel Associate";
 								 
 								 default:									 
									 return "Cancel Associate";
							} 
 					}
				}


				 ///<summary>角色授權</summary>
				public static string UserList_RolesAuthorize
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "角色授权";
								 case "zh-HK":
									 return "角色授權";
								  case "en-US":
									 return "Roles Authorize";
 								 
 								 default:									 
									 return "Roles Authorize";
							} 
 					}
				}


				 ///<summary>系統用戶列表</summary>
				public static string UserList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统用户列表";
								 case "zh-HK":
									 return "系統用戶列表";
								  case "en-US":
									 return "System User List";
 								 
 								 default:									 
									 return "System User List";
							} 
 					}
				}


				 ///<summary>新 增</summary>
				public static string UserRegister_AddNew
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "新 增";
								 case "zh-HK":
									 return "新 增";
								  case "en-US":
									 return "Add New";
 								 
 								 default:									 
									 return "Add New";
							} 
 					}
				}


				 ///<summary>Email或手機號碼</summary>
				public static string UserRegister_EmailPhoneNumberUserName_Required
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "Email或者手机号码";
								 case "zh-HK":
									 return "Email或手機號碼";
								  case "en-US":
									 return "Email OR PhoneNumber";
 								 
 								 default:									 
									 return "Email OR PhoneNumber";
							} 
 					}
				}


				 ///<summary>可能輸入非法數據！</summary>
				public static string UserRegister_MayBeInputIllegalData
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "可能输入非法数据！";
								 case "zh-HK":
									 return "可能輸入非法數據！";
								  case "en-US":
									 return "MayBe Input Illegal Data ！";
 								 
 								 default:									 
									 return "MayBe Input Illegal Data ！";
							} 
 					}
				}


				 ///<summary>現在添加雇員資料嗎？</summary>
				public static string UserRegister_NeedToAddEmployee
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "现在添加雇员资料吗？";
								 case "zh-HK":
									 return "現在添加雇員資料嗎？";
								  case "en-US":
									 return "Need To Add Employee？";
 								 
 								 default:									 
									 return "Need To Add Employee？";
							} 
 					}
				}


				 ///<summary>No，現在不需要添加雇員資料</summary>
				public static string UserRegister_RefuseUserRegisterTips
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "No，现在不需要添加雇员资料";
								 case "zh-HK":
									 return "No，現在不需要添加雇員資料";
								  case "en-US":
									 return "No，Now not yet.";
 								 
 								 default:									 
									 return "No，Now not yet.";
							} 
 					}
				}


				 ///<summary>注冊失敗 ！</summary>
				public static string UserRegister_RegistedFailure
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注册失败 ！";
								 case "zh-HK":
									 return "注冊失敗 ！";
								  case "en-US":
									 return "Registed Failure ！";
 								 
 								 default:									 
									 return "Registed Failure ！";
							} 
 					}
				}


				 ///<summary>注冊成功 ！</summary>
				public static string UserRegister_RegistedSuccess
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注册成功 ！";
								 case "zh-HK":
									 return "注冊成功 ！";
								  case "en-US":
									 return "Registed Success ！";
 								 
 								 default:									 
									 return "Registed Success ！";
							} 
 					}
				}


				 ///<summary>系統用戶注冊</summary>
				public static string UserRegister_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "系统用户注册";
								 case "zh-HK":
									 return "系統用戶注冊";
								  case "en-US":
									 return "System User Restistration";
 								 
 								 default:									 
									 return "System User Restistration";
							} 
 					}
				}


				 ///<summary>角色授權</summary>
				public static string UserRolesAssignList_RolesAssign
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "角色授权";
								 case "zh-HK":
									 return "角色授權";
								  case "en-US":
									 return "Roles Assignment";
 								 
 								 default:									 
									 return "Roles Assignment";
							} 
 					}
				}


				 ///<summary>用戶角色授權</summary>
				public static string UserRolesAssignList_Title
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "用户角色授权";
								 case "zh-HK":
									 return "用戶角色授權";
								  case "en-US":
									 return "User Roles Assignment";
 								 
 								 default:									 
									 return "User Roles Assignment";
							} 
 					}
				}


				 ///<summary>代碼無效</summary>
				public static string VerifyCode_InvaliCode
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "代码无效";
								 case "zh-HK":
									 return "代碼無效";
								  case "en-US":
									 return "Invali Code";
 								 
 								 default:									 
									 return "Invali Code";
							} 
 					}
				}


				 ///<summary>注 冊</summary>
				public static string Views_GeneralUI_Register
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "注 册";
								 case "zh-HK":
									 return "注 冊";
								  case "en-US":
									 return "Regist";
 								 
 								 default:									 
									 return "Regist";
							} 
 					}
				}


				 ///<summary>FRIDAY</summary>
				public static string WeekDayType_FRIDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "FRIDAY";
								 case "zh-HK":
									 return "FRIDAY";
								  case "en-US":
									 return "FRIDAY";
 								 
 								 default:									 
									 return "FRIDAY";
							} 
 					}
				}


				 ///<summary>MONDAY</summary>
				public static string WeekDayType_MONDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "MONDAY";
								 case "zh-HK":
									 return "MONDAY";
								  case "en-US":
									 return "MONDAY";
 								 
 								 default:									 
									 return "MONDAY";
							} 
 					}
				}


				 ///<summary>SATURDAY</summary>
				public static string WeekDayType_SATURDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "SATURDAY";
								 case "zh-HK":
									 return "SATURDAY";
								  case "en-US":
									 return "SATURDAY";
 								 
 								 default:									 
									 return "SATURDAY";
							} 
 					}
				}


				 ///<summary>SUNDAY</summary>
				public static string WeekDayType_SUNDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "SUNDAY";
								 case "zh-HK":
									 return "SUNDAY";
								  case "en-US":
									 return "SUNDAY";
 								 
 								 default:									 
									 return "SUNDAY";
							} 
 					}
				}


				 ///<summary>THURSDAY</summary>
				public static string WeekDayType_THURSDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "THURSDAY";
								 case "zh-HK":
									 return "THURSDAY";
								  case "en-US":
									 return "THURDAY";
 								 
 								 default:									 
									 return "THURDAY";
							} 
 					}
				}


				 ///<summary>TUEDAY</summary>
				public static string WeekDayType_TUEDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "TUEDAY";
								 case "zh-HK":
									 return "TUEDAY";
								  case "en-US":
									 return "TUEDAY";
 								 
 								 default:									 
									 return "TUEDAY";
							} 
 					}
				}


				 ///<summary>WEDNESDAY</summary>
				public static string WeekDayType_WEDNESDAY
				{
					get
					{

						 switch (LangUtilities.LanguageCode)
							{
								 case "zh-CN":
									 return "WEDNESDAY";
								 case "zh-HK":
									 return "WEDNESDAY";
								  case "en-US":
									 return "WEDNESDAY";
 								 
 								 default:									 
									 return "WEDNESDAY";
							} 
 					}
				}


        #endregion
         
    }

}
