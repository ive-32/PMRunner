namespace GameScene.Level.UiElements
{
    public class UIValue<T>
    {
        private T _value;
        public T Value
        {
            get 
            { 
                IsChanged = false;
                return _value;
            }
            set { 
                IsChanged = true;
                _value = value;
            }
        }

        public UIValue(T newValue)
        {
            _value = newValue;
            IsChanged = true;
        }

        public bool IsChanged = false;

        public T GetCurrentValue() => _value;
        public T FixCurrentValue() => Value;
        
    }
}