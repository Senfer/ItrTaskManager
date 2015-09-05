using Mvc.Mailer;

namespace CourseProject.Mailers
{ 
    public interface ICommentMailer
    {
			MvcMailMessage CommentPosted();
			MvcMailMessage Liked();
	}
}