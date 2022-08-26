using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception // Aspect:Methodun başında sonunda ortasında hata verdiğinde Çalışcak şeyler
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // Instance : Product product = new Product(); 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // PrductValidator Base in Genreic argümanların 0. argümanalrın tipini yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //invocation method(Add vs.) demek
            // bwnim methodumdakileri gezip Base deki elemanalrın tipi ile eşleşiyo mu diye kontrol ediyor
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
