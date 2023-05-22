using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace WebAuth.Client.Components
{
    public class CustomValidation : ComponentBase
    {
        private ValidationMessageStore? _validationMessageStore;
        [CascadingParameter]
        private EditContext? CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            if (CurrentEditContext is null)
            {
                throw new InvalidOperationException($"Invalid {nameof(CurrentEditContext)}");
            }
            _validationMessageStore = new ValidationMessageStore(CurrentEditContext);

            CurrentEditContext.OnValidationRequested += (s, e) => _validationMessageStore?.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => _validationMessageStore?.Clear(e.FieldIdentifier);
        }
        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            if (CurrentEditContext is not null)
            {
                foreach (var error in errors)
                {
                    _validationMessageStore?.Add(CurrentEditContext.Field(error.Key), error.Value);
                }
                CurrentEditContext.NotifyValidationStateChanged();
            }
        }
        public void ClearErrors()
        {
            _validationMessageStore?.Clear();
            CurrentEditContext?.NotifyValidationStateChanged();
        }
    }
}