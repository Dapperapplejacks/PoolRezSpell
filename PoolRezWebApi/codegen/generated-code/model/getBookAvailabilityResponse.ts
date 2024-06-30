/**
 * PoolRezWebApi
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { Availability } from './availability';

export interface GetBookAvailabilityResponse { 
    itemId?: number;
    itemDescription?: string;
    itemBarcodeId?: string;
    duration?: string;
    clubId?: number;
    clubName?: string;
    price?: number;
    priorityAssignedResourceTypeId?: number;
    customerHasPunchesForItem?: boolean;
    allowOnlineMemberPurchase?: boolean;
    dividePriceByMembers?: boolean;
    availability?: Array<Availability>;
    maximumCustomersPerAppointment?: number;
}