//using LibraryCommon.Handlers.Attributes;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LibraryCommon.Handlers.ModelBinders
//{
//    public class StringToListBinder<T> : IModelBinder
//    {
//        const string _defaultSeparator = Separators.Comma;

//        public Task BindModelAsync(ModelBindingContext modelBindingContext)
//        {
//            var modelName = modelBindingContext.ModelName;
//            var valueProviderResult = modelBindingContext.ValueProvider.GetValue(modelName);

//            if (valueProviderResult == ValueProviderResult.None)
//                return Task.CompletedTask;

//            modelBindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

//            var result = valueProviderResult.FirstValue;

//            if (string.IsNullOrEmpty(result))
//                return Task.CompletedTask;


//            string separator = GetSeparatorFromAttribute(modelBindingContext);

//            var valueList = result.Split(separator);

//            List<T> values = new List<T>();



//            return Task.CompletedTask;
//        }

//        private string GetSeparatorFromAttribute(ModelBindingContext modelBindingContext)
//        {
//            var propertyAttributes = ((DefaultModelMetadata)((DefaultModelBindingContext)modelBindingContext).ModelMetadata)
//                .Attributes.PropertyAttributes.Cast<Attribute>().ToList();

//            if (propertyAttributes is null)
//                return _defaultSeparator;

//            if (!propertyAttributes.Any(a => a.GetType() == typeof(StringSeparatorAttribute)))
//                return _defaultSeparator;

//            var stringSeparator = propertyAttributes.FirstOrDefault(a => a.GetType() == typeof(StringSeparatorAttribute));

//            if (stringSeparator is null || string.IsNullOrEmpty(((StringSeparatorAttribute)stringSeparator).Separator))
//                return _defaultSeparator;

//            return ((StringSeparatorAttribute)stringSeparator).Separator;

//        }

//    }
//}
