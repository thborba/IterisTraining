import "./Curriculum.css";
import PersonalInfo from "../PersonalInfo/PersonalInfo";
import References from "../References/References";
import Skills from "../Skills/Skills"
import Profile from "../Profile/Profile";
import Formation from "../Formation/Formation";

function Curriculum() {
  return (
    <div className="App">
      <section class="container">
        <div class="curriculum d-flex row">
          <div class="curriculum_left d-flex column">
            <PersonalInfo> </PersonalInfo>
            <div class="leftHorizontalLine"></div>
            <References> </References>
            <div class="leftHorizontalLine"></div>
            <Skills> </Skills>
          </div>

          <div class="curriculum_right d-flex column">
            <Profile> </Profile>
            <div class="rightHorizontalLine"></div>
            <Formation title = "FORMAÇÃO" id = "education"> </Formation>
            <div class="rightHorizontalLine"></div>
            <Formation title = "EXPERIÊNCIA" id = "experience"> </Formation>
          </div>
        </div>
      </section>
    </div>
  );
}

export default Curriculum;
