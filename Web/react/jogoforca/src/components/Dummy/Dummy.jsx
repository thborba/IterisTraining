import "./Dummy.css";

function Dummy() {
  return (
    <div class="dummy">
      <img
        id="head"
        src="../../../assets/images/head.png"
        hidden="svc.isHidden[0]"
        alt=""
      >
        {" "}
      </img>
      <img
        id="body"
        src="../../../assets/images/corpo.png"
        hidden="svc.isHidden[1]"
        alt=""
      ></img>
      <img
        id="rightArm"
        src="../../../assets/images/bracoDireita.png"
        hidden="svc.isHidden[2]"
        alt=""
      ></img>
      <img
        id="leftArm"
        src="../../../assets/images/bracoEsquerdo.png"
        hidden="svc.isHidden[3]"
        alt=""
      ></img>
      <img
        id="rightLeg"
        src="../../../assets/images/pernaDireita.png"
        hidden="svc.isHidden[4]"
        alt=""
      ></img>
      <img
        id="leftLeg"
        src="../../../assets/images/pernaEsquerda.png"
        hidden="svc.isHidden[5]"
        alt=""
      ></img>
    </div>
  );
}


export default Dummy;