var renderer, scene, camera, mesh, controls;
var frontLight, backLight, ambLight;
var snowman;
Snowman = function() {
    this.blanco = new THREE.MeshLambertMaterial({
        color: 0xffffff,
        shading: THREE.SmoothShading
    });
    this.negro = new THREE.MeshLambertMaterial({
        color: 0x212121,
        shading: THREE.SmoothShading
    })
    this.rojo = new THREE.MeshLambertMaterial({
        color: 0x2196F3,
        shading: THREE.SmoothShading
    })
    this.naranja = new THREE.MeshLambertMaterial({
        color: 0xFF5722,
        shading: THREE.SmoothShading
    })
    this.cafe = new THREE.MeshLambertMaterial({
        color: 0x5D4037,
        shading: THREE.SmoothShading
    })
    var base = new THREE.Mesh(new THREE.SphereGeometry(350, 400, 400), this.blanco);
    var cabeza = new THREE.Mesh(new THREE.SphereGeometry(130, 50, 50), this.blanco);
    var cono = new THREE.Mesh(new THREE.CylinderGeometry(150, 90, 200,0), this.negro);
    var borde_sombrero = new THREE.Mesh(new THREE.CylinderGeometry(200, 170, 10,0), this.negro);
    borde_sombrero.translateY(-90);
    var cinta_sombrero = new THREE.Mesh(new THREE.CylinderGeometry(120, 90, 30,0), this.rojo);
    cinta_sombrero.translateY(-60);
    cinta_sombrero.translateZ(15);
    cinta_sombrero.translateX(5);

    this.sombrero = new THREE.Group();
    this.sombrero.add(cono);
    this.sombrero.add(borde_sombrero);
    this.sombrero.add(cinta_sombrero);
    this.sombrero.translateY(200);

    var narizSeg0 = new THREE.Mesh(new THREE.CylinderGeometry(50,8, 200,0), this.naranja);
    narizSeg0.rotation.x=-Math.PI / 2;

    this.nariz = new THREE.Group();
    this.nariz.add(narizSeg0);
    this.nariz.translateZ(130);

    var ojoIzquierdo = new THREE.Mesh(new THREE.BoxGeometry(35, 35, 10), this.negro);
    ojoIzquierdo.translateX(-50);
    var ojoDerecho = new THREE.Mesh(new THREE.BoxGeometry(35, 35, 10), this.negro);
    ojoDerecho.translateX(50);

    this.ojo = new THREE.Group();
    this.ojo.add(ojoIzquierdo);
    this.ojo.add(ojoDerecho);
    this.ojo.translateY(50);
    this.ojo.translateZ(115);

    var boca = new THREE.Mesh(new THREE.BoxGeometry(30, 30, 20), this.negro);
    var llboca = boca.clone();
    var lboca = boca.clone();
    var rboca = boca.clone();
    var rrboca = boca.clone();
    llboca.translateX(-60);
    llboca.translateY(25);
    lboca.translateX(-30);
    lboca.translateY(5);
    rboca.translateY(5);
    rboca.translateX(30);
    rrboca.translateY(25);
    rrboca.translateX(60);

    this.boca = new THREE.Group();
    this.boca.add(llboca);
    this.boca.add(lboca);
    this.boca.add(boca);
    this.boca.add(rboca);
    this.boca.add(rrboca);
    this.boca.translateY(-50);
    this.boca.translateZ(115);

    var chalina = new THREE.Mesh(new THREE.CylinderGeometry(170, 170, 20,50), this.rojo);

    this.grupo_chalina = new THREE.Group();
    this.grupo_chalina.add(chalina);

    this.grupo_chalina.translateY(-90);

    this.grupo_cabeza = new THREE.Group();
    this.grupo_cabeza.add(cabeza);
    this.grupo_cabeza.add(this.sombrero);
    this.grupo_cabeza.add(this.nariz);
    this.grupo_cabeza.add(this.ojo);
    this.grupo_cabeza.add(this.boca);
    this.grupo_cabeza.add(this.grupo_chalina);

    this.grupo_cabeza.translateY(612);

    var cuerpo = new THREE.Mesh(new THREE.SphereGeometry(200, 200, 200), this.blanco);

    var brazoDerecho = new THREE.Mesh(new THREE.BoxGeometry(500, 20, 20), this.cafe),
        brazoIzquierdo = brazoDerecho.clone();

    this.brazoDerecho = new THREE.Group();
    this.brazoDerecho.add(brazoDerecho);
    this.brazoDerecho.translateX(125);
    this.brazoIzquierdo = new THREE.Group();
    this.brazoIzquierdo.add(brazoIzquierdo);
    this.brazoIzquierdo.translateX(-125);

    this.hombroDerecho = new THREE.Group();
    this.hombroDerecho.add(this.brazoDerecho);
    this.hombroDerecho.translateX(140);
    this.hombroDerecho.translateY(50);
    this.hombroDerecho.rotation.z = Math.PI / 4; 
    this.hombroIzquierdo = new THREE.Group();
    this.hombroIzquierdo.add(this.brazoIzquierdo);
    this.hombroIzquierdo.translateX(-180);
    this.hombroIzquierdo.translateY(50);
    this.hombroIzquierdo.rotation.z = Math.PI / 4;

    var boton0 = new THREE.Mesh(new THREE.BoxGeometry(35, 35, 100), this.negro),
        boton1 = boton0.clone(),
        boton2 = boton0.clone();
    boton0.translateY(-60);
    boton2.translateY(70);

    this.grupo_boton = new THREE.Group();
    this.grupo_boton.add(boton0);
    this.grupo_boton.add(boton1);
    this.grupo_boton.add(boton2);
    this.grupo_boton.translateZ(155);
    this.grupo_boton.translateY(15);
    this.grupo_boton.translateX(15);

    this.grupo_cuerpo = new THREE.Group();
    this.grupo_cuerpo.add(cuerpo);
    this.grupo_cuerpo.add(this.hombroDerecho);
    this.grupo_cuerpo.add(this.hombroIzquierdo);
    this.grupo_cuerpo.add(this.grupo_boton);
    this.grupo_cuerpo.translateY(350);

    this.grupo_snowman = new THREE.Group();
    this.grupo_snowman.add(base);
    this.grupo_snowman.add(this.grupo_cuerpo);
    this.grupo_snowman.add(this.grupo_cabeza);
}

function construirSnowman() {
    snowman = new Snowman();
    scene.add(snowman.grupo_snowman);
};

function crearLuces() {
    frontLight = new THREE.DirectionalLight(0xffffff, 0.6);
    frontLight.position.set(700, 1500, 1500);
    frontLight.position.multiplyScalar(1.3);
    frontLight.target = snowman.grupo_snowman.children[2];
    frontLight.castShadow = true;
    var d = 1200;
    frontLight.shadow.camera.left = -d;
    frontLight.shadow.camera.right = d;
    frontLight.shadow.camera.top = d;
    frontLight.shadow.camera.bottom = -d;
    frontLight.shadow.camera.far = 5000;
    backLight = new THREE.DirectionalLight(0xffffff, 0.6);
    backLight.position.set(-700, 3000, -3000);
    ambLight = new THREE.AmbientLight(0x474747);
    light = new THREE.HemisphereLight(0xffffdd, 0xffffdd, .2)
    scene.add(frontLight);
    scene.add(backLight);
    scene.add(ambLight);
    scene.add(light);
}

function init() {
    renderer = new THREE.WebGLRenderer({
        alpha: true,
        antialias: true
    });
    renderer.setSize(window.innerWidth, window.innerHeight);
    renderer.shadowMap.enabled = false;
    renderer.shadowMap.soft = false;
    document.getElementById('container').appendChild(renderer.domElement);

    scene = new THREE.Scene();

    camera = new THREE.PerspectiveCamera(60, window.innerWidth / window.innerHeight, 1, 10000);
    camera.position.set(500, 1000, 2000);
    camera.lookAt(new THREE.Vector3(0, 800, 0));
    scene.add(camera);

    
    construirSnowman();
    crearLuces();
    controls=new THREE.OrbitControls(camera,renderer.domElement);
}

init();

function updateFrame() {
    renderer.render(scene, camera);
    requestAnimationFrame(updateFrame);
}
requestAnimationFrame(updateFrame);