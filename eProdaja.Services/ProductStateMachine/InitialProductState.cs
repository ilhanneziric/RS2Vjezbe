using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProductStateMachine
{
    public class InitialProductState : BaseState
    {
        public override void Insert(ProizvodiInsertRequest request)
        {
            CurrentEntity.StateMachine = "draft";
        }
    }
}
