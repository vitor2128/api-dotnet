using System.Collections.Generic;
using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
  public class User : Base
    {
        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Passoword { get; private set; }

        protected User() { }

        public User(string name, string email, string passoword)
        {
            Name = name;
            Email = email;
            Passoword = passoword;
            _errors = new List<string>();

            Validate();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string passoword)
        {
            Passoword = passoword;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);

            }

            return true;
        }
    }
}