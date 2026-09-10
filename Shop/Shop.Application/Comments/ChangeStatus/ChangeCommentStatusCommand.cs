using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Shop.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand( long Id, CommentStatus Status) : IBaseCommand;
  
}
