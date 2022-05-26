namespace Library.Contracts.DTO
{
    /**
     * <summary>
     * Определяет возможность переструктурирования данных между клиентской и серверной частью
     * </summary>
     * <typeparam name="T"></typeparam>
     */
    public interface IDto<out T>
    {
        /**
         * <summary>Д
         * Преобразует экземпляр класса в экземпляр Data Transfer Object
         * </summary>
         * <returns></returns>
         */
        T ToDto();
    }
}