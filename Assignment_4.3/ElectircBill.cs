using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4._3
{
    delegate void UnitAmount(float a);
    internal class ElectircBill
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public float UnitConsumed { get; set; }

        private string _textCharged;
        private float _amountCharge;
        private float _surChargeAmount;
        private float _netAmountPaid;

        public ElectircBill(int id, string name, float units)
        {
            CustomerId = id;
            CustomerName = name;
            UnitConsumed = units;
        }

        public bool IsOverAmount(float cost)
        {
            return cost > 400;
        }

        public float AddSurCharge(float cost)
        {
            return 0.15f * cost;
        }

        public float CheckSurCharge(float cost)
        {
            if (IsOverAmount(cost)) return AddSurCharge(cost);
            return 0;
        }

        public void SmallUnits(float units)
        {
            _textCharged = "@$ 1.20 per unit";
            _amountCharge = 1.20f * units;
            _surChargeAmount = CheckSurCharge(_amountCharge);
            _netAmountPaid = _amountCharge + _surChargeAmount;
        }

        public void MediumUnits(float units)
        {
            _textCharged = "@$ 1.50 per unit";
            _amountCharge = 1.50f * units;
            _surChargeAmount = CheckSurCharge(_amountCharge);
            _netAmountPaid = _amountCharge + _surChargeAmount;
        }

        public void BigUnits(float units)
        {
            _textCharged = "@$ 1.80 per unit";
            _amountCharge = 1.80f * units;
            _surChargeAmount = CheckSurCharge(_amountCharge);
            _netAmountPaid = _amountCharge + _surChargeAmount;
        }

        public void MaxUnits(float units)
        {
            _textCharged = "@$ 2.00 per unit";
            _amountCharge = 2.00f * units;
            _surChargeAmount = CheckSurCharge(_amountCharge);
            _netAmountPaid = _amountCharge + _surChargeAmount;
        }

        public void CalculateUnits(float units, UnitAmount amount)
        {
            amount(units);
        }

        public void StartBilling()
        {
            if (UnitConsumed > 0 && UnitConsumed <= 199)
            {
                CalculateUnits(UnitConsumed, SmallUnits);
            }
            else if (UnitConsumed >= 200 && UnitConsumed < 400)
            {
                CalculateUnits(UnitConsumed, MediumUnits);
            }
            else if (UnitConsumed >= 400 && UnitConsumed < 600)
            {
                CalculateUnits(UnitConsumed, BigUnits);
            }
            else if(UnitConsumed >= 600)
            {
                CalculateUnits(UnitConsumed, MaxUnits);
            }

        }

        public override string ToString()
        {
            return $"Customer IDNO: {CustomerId}\n" +
                $"Customer Name: {CustomerName}\n" +
                $"Unit Consumed: {UnitConsumed:F2}\n" +
                $"Amount Charges {_textCharged}: {_amountCharge:F2}\n" +
                $"Surcharge Amount: {_surChargeAmount:F2}\n" +
                $"Net Amount Paid By the Customer: {_netAmountPaid:F2}";
        }

    }
}
