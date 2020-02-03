namespace ELearningApp.Core.Helpers
{
    public static class Constants
    {
        public const string NotFound = "Not Found";
        public const string EmailSenderException =
            "An error occured while sending confirmation email, please try again";
        public const string EmailVerificationException = "Unable to verify email";
        public const string LoginFailed =
            "Login Failed, please make sure your email is verified and provided password is correct";
        public const string UserNotFound = "User with specified username does not exist";
        public const string UserAlreadyExists = "User with specified username already exists";
        public const string IncorrectPassword = "Password is incorrect";
        public const string RegistrationError =
            "An error occurred during registration, please make sure an email address is not already signed up";
        public const string Conflict = "Conflict";

    }
}