namespace CorporateAPI.Application.Helpers
{
    public static class TranslationHelper
    {
        public static void UpdateOrAddTranslations<TTranslation, TDto>(
            ICollection<TTranslation> existingTranslations,
            IEnumerable<TDto> incomingDtos,
            Func<TDto, string> langCodeSelector,
            Func<string, Guid> langIdResolver,
            Action<TDto, TTranslation> mapDtoToEntity)
            where TTranslation : class, new()
        {
            foreach (var dto in incomingDtos)
            {
                var langCode = langCodeSelector(dto);
                var langId = langIdResolver(langCode);

                var existing = existingTranslations.FirstOrDefault(t =>
                    typeof(TTranslation).GetProperty("LangId")?.GetValue(t) is Guid id && id == langId);

                if (existing != null)
                {
                    mapDtoToEntity(dto, existing);
                }
                else
                {
                    var newTranslation = new TTranslation();
                    typeof(TTranslation).GetProperty("LangId")?.SetValue(newTranslation, langId);
                    mapDtoToEntity(dto, newTranslation);
                    existingTranslations.Add(newTranslation);
                }
            }
        }
    }

}
