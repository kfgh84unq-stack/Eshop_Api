using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long CommentId,String Text, long UserId, long ProductId) : IBaseCommand;
}
