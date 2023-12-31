﻿using TesteMainteneace.Domain.Entities.Order.Enun;

namespace TesteMainteneace.Application.UseCases.OrderService
{
    public static class ValidateEnunInOrderService
    {
        public static string ValidatePriority(EPriority priority)
        {
            switch (priority)
            {
                case EPriority.LOW:
                    return "BAIXO";
                case EPriority.MIDDLE:
                    return "MÉDIO";
                case EPriority.HIGH:
                    return "ALTO";
                default:
                    return "Prioridade não registrada";
            }
        }
        public static string ValidateSituacion(ESituationOrderService situacion)
        {
            switch (situacion)
            {
                case ESituationOrderService.WAITING_ATRIBUIATION:
                    return "AGUARDANDO ATRIBUIÇÃO";
                case ESituationOrderService.ORDER_INVALID:
                    return "ORDEM INVÁLIDA";
                case ESituationOrderService.WAITING_MAINTENEACE:
                    return "AGUARDANDO MANUTENÇÃO";
                case ESituationOrderService.IN_MAINTENEACE:
                    return "EM MANUTENÇÃO";
                case ESituationOrderService.WAITING_PARTS:
                    return "AGUARDANDO PEÇAS";
                case ESituationOrderService.WAITING_AUTORIZATION_PARTS:
                    return "PEÇAS AUTORIZADAS";
                case ESituationOrderService.MAINTENEACE_END:
                    return "MANUTENÇÃO FINALIZADA";
                case ESituationOrderService.MAINTENEACE_INVALID:
                    return "MANUTENÇÃO INVÁLIDA";
                case ESituationOrderService.ORDER_END:
                    return "ORDEM FINALIZADA";
                default:
                    return "STATUS NÃO ENCONTRADO";
            }
        }

        public static string ValidateTypeMainteneace(ETypeMainteneace typeMainteneace)
        {
            switch (typeMainteneace)
            {
                case ETypeMainteneace.CORRECTIVE:
                    return "CORRETIVA";
                case ETypeMainteneace.PREVENTIVE:
                    return "PREVENTIVA";
                case ETypeMainteneace.PREDICTIVE:
                    return "PREDITIVA";
                default:
                    return "TIPO DE MANUTENÇÃO NÃO ENCONTRADA!";

            }
        }
        public static string ValidateCategoryService(ECategoty category)
        {
            switch (category) 
            {
                case ECategoty.ELETRICO:
                    return "ELÉTRICO";
                case ECategoty.MECANICO:
                    return "MECÂNICO";
                case ECategoty.HIDRAULICO:
                    return "HIDRÁULICO";
                case ECategoty.SERRALHERIA:
                    return "SERRALHERIA";
                case ECategoty.JARDINAGEM:
                    return "JARDINAGEM";
                case ECategoty.ALVENARIA:
                    return "ALVERNARIA";
                case ECategoty.OUTRO:
                    return "OUTRO";
                default:
                    return "NÃO ENCONTRADO";
            }
        }
    }
}
