export * from './authentication.service';
import { AuthenticationService } from './authentication.service';
export * from './reservation.service';
import { ReservationService } from './reservation.service';
export const APIS = [AuthenticationService, ReservationService];
