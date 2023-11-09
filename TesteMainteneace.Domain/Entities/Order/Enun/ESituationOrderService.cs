namespace TesteMainteneace.Domain.Entities.Order.Enun
{
    public enum ESituationOrderService
    {
        WAITING_ATRIBUIATION = 0,
        ORDER_INVALID = 1,
        WAITING_MAINTENEACE = 2,
        IN_MAINTENEACE = 3,
        WAITING_PARTS = 4,
        WAITING_AUTORIZATION_PARTS = 5,
        MAINTENEACE_END = 6,
        MAINTENEACE_INVALID = 7,
        ORDER_END = 8
    }
}
