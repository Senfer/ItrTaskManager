using Mvc.Mailer;

namespace CourseProject.Mailers
{ 
    public interface IReportMailer
    {
			MvcMailMessage ReportProduced();
			MvcMailMessage ReportSent();
			MvcMailMessage ReportLoading();
	}
}