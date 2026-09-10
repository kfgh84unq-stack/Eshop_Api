using Common.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand(String Text,long UserId,long ProductId) : IBaseCommand;
}
