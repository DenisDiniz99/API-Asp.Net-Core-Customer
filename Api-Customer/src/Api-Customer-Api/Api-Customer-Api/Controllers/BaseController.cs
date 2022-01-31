using Api_Customer_Api.Extensions;
using Api_Customer_Business.Contracts;
using Api_Customer_Business.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Api_Customer_Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected INotifier _notifier;

        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected ActionResult<IEnumerable<T>> ResponseGet<T>(IEnumerable<T> result)
        {
            if (result == null || !result.Any())
                return NoContent();

            return Ok(result);
        }

        protected ActionResult<T> ResponseGet<T>(T result)
        {
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        protected ActionResult ResponsePut()
        {
            if (ValidOperation())
                return NoContent();

            var notifications = _notifier.GetNotifications();
            var errors = new List<string>();

            foreach(var item in notifications)
            {
                errors.Add(item.Message);
            }

            return BadRequest(new ResponseResult
            {
                Title = "Error",
                Status = StatusCodes.Status400BadRequest,
                Errors = new ResponseResultMessageErrors {
                    Messages = errors
                }

            });
        }

        protected ActionResult ResponseDelete(Guid id)
        {
            if (ValidOperation())
            {
                if (id == null)
                    return NotFound();

                return Ok(id);
            }

            var notifications = _notifier.GetNotifications();
            var errors = new List<string>();

            foreach (var item in notifications)
            {
                errors.Add(item.Message);
            }

            return BadRequest(new ResponseResult
            {
                Title = "Error",
                Status = StatusCodes.Status400BadRequest,
                Errors = new ResponseResultMessageErrors
                {
                    Messages = errors
                }

            });
        }


        protected ActionResult ResponsePost(object result = null)
        {
            if (ValidOperation())
            {
                if (result == null)
                    return NoContent();
                return Ok(result);
            }

            var notifications = _notifier.GetNotifications();
            var errors = new List<string>();

            foreach (var item in notifications)
            {
                errors.Add(item.Message);
            }

            return BadRequest(new ResponseResult
            {
                Title = "Error",
                Status = StatusCodes.Status400BadRequest,
                Errors = new ResponseResultMessageErrors
                {
                    Messages = errors
                }

            });
        }

        protected void InvalidModelError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach(var e in errors)
            {
                var error = e.Exception == null ? e.ErrorMessage : e.Exception.Message;
                Notify(error);
            }
        }

        protected ActionResult ResponseError()
        {
            return BadRequest(new ValidationProblemDetails(ModelState));
        }
    }
}