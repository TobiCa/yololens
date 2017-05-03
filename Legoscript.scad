
// LegoStenGenerator


// StenMaal, x og y er hvor mange knopper stenen skal have, H er true/false om den er hoej. Ulige tal er lidt derpy

// Bare giv maalene ind, tryk F6 og exporter som .STL

SX = 4;
SY = 2;
H  = true;


//Made By Thure


//LEGO mål
KH = 9.6;
FH = 3.2;

//1*1 hoej
if((SX==1)&&(SY==1)&& (H==true)){
    translate([4,4,KH]) cylinder(h= 2, d=5, $fn=50);
    difference(){
        cube([8,8,KH]);
        translate([1.2,1.2,0]) cube([5.6,5.6,KH-1]);
    }
}
//1*1 flad
else if((SX==1)&&(SY==1)&& (H==false)){
    translate([4,4,FH]) cylinder(h= 2, d=5, $fn=50);
        difference(){
            cube([8,8,FH]);
            translate([1.2,1.2,0]) cube([5.6,5.6,FH-1]);
        }
    }

//1*x høj
else if ((SX==1)&&(H==true)||(SY==1)&&(H==true)){
    i = max(SX,SY);
    difference(){
        cube([8*i,8,KH]);
        translate([1.2,1.2,0]) cube([(8*i)-2.4,5.6,KH-1]);
    }
    for (u = [1:i]){
        translate([(8*(u-1))+4,4,KH]) cylinder(h= 2, d=5, $fn=50);
    }
    for (u = [1:(i-1)]){
        translate([(8*(u)),4,0]) cylinder(h= KH, d=3, $fn=50);
    }
}
//1*x flad
else if ((SX==1)&&(H==false)||(SY==1)&& (H==false)){
    i = max(SX,SY);
    difference(){
        cube([8*i,8,FH]);
        translate([1.2,1.2,0]) cube([(8*i)-2.4,5.6,FH-1]);
    }
    for (u = [1:i]){
        translate([(8*(u-1))+4,4,FH]) cylinder(h= 2, d=5, $fn=50);
    }
    for (u = [1:(i-1)]){
        translate([(8*u),4,0]) cylinder(h= FH, d=3, $fn=50);
    }
}
//2*x høj
else if ((SX==2)&&(H==true)||(SY==2)&&(H==true)){
    i = max(SX,SY);
    difference(){
        cube([8*i,16,KH]);
        translate([1.2,1.2,0]) cube([(8*i)-2.4,13.6,KH-1]);
    }
    for (u = [1:i]){
        translate([(8*(u-1))+4,4,KH]) cylinder(h= 2, d=5, $fn=50);
        translate([(8*(u-1))+4,12,KH]) cylinder(h= 2, d=5, $fn=50);
    }
    for (u = [1:(i-1)]){
        translate([(8*u),8,0]){
           difference(){
                cylinder(h= KH, r=3.155, $fn=50);
                cylinder(h= KH, r=2.405, $fn=50);
            }
       }
    }
}

//2*x flad
else if ((SX==2)&&(H==false)||(SY==2)&&(H==false)){
    i = max(SX,SY);
    difference(){
        cube([8*i,16,FH]);
        translate([1.2,1.2,0]) cube([(8*i)-2.4,13.6,FH-1]);
    }
    for (u = [1:i]){
        translate([(8*(u-1))+4,4,FH]) cylinder(h= 2, d=5, $fn=50);
        translate([(8*(u-1))+4,12,FH]) cylinder(h= 2, d=5, $fn=50);
    }
    for (u = [1:(i-1)]){
        translate([(8*u),8,0]){
           difference(){
                cylinder(h= FH, r=3.155, $fn=50);
                cylinder(h= FH, r=2.405, $fn=50);
            }
       }
    }
}
//3+*3+ høj
else if ((SX>2)&&(SY>2)&&(H==true)){
    
    difference(){
        cube([8*SX,8*SY,KH]);
        translate([1.2,1.2,0]) cube([(8*SX)-2.4,(8*SY)-2.4,KH-1]);
    }
    for (u = [1:SX]){
        for (o = [1:SY]){
        translate([(8*(u-1))+4,(8*(o-1))+4,KH]) cylinder(h= 2, d=5, $fn=50);
    }}
    for (u = [1:2:(SX-1)]){
        for (o = [1:2:(SY-1)]){
        translate([(8*u),(8*o),0]){
            difference(){
                cylinder(h= KH, r=3.155, $fn=50);
                cylinder(h= KH, r=2.405, $fn=50);
            }
        }
    }}

    for (u = [1:2:(SX-2)]){
        for (o = [1:2:(SY-2)]){
        translate([(8*u)+8,(8*o)+8,0]){
            difference(){
                union(){
                    cylinder(h= KH, r=3.155, $fn=50);
                    translate([0,-8,2]) cube ([0.75,16,KH-2]);
                    translate([-8,0,2]) cube ([16,0.75,KH-2]);
                }
                    cylinder(h= KH, r=2.405, $fn=50);
            }
        }

        }
    }
    for (u = [1:2:(SX-2)]){
        for (o = [1:2:(SY-2)]){
        translate([(8*u)+8,0,0]){
            translate([0,0,2]) cube ([0.75,8,KH-2]);
        }
        translate([0,(8*o)+8,0]){
            translate([0,0,2]) cube ([8,0.75,KH-2]);
        }
        translate([0,(8*o)+8,0]){
            translate([(8*SX)-8,0,2]) cube ([8,0.75,KH-2]);
        }
        translate([(8*u)+8,0,0]){   
            translate([0,(8*SY)-8,2]) cube ([0.75,8,KH-2]);
        }
    }}
    
    }
//3+*3+ flad
else if ((SX>2)&&(SY>2)&&(H==false)){
    
    difference(){
        cube([8*SX,8*SY,FH]);
        translate([1.2,1.2,0]) cube([(8*SX)-2.4,(8*SY)-2.4,FH-1]);
    }
    for (u = [1:SX]){
        for (o = [1:SY]){
        translate([(8*(u-1))+4,(8*(o-1))+4,FH]) cylinder(h= 2, d=5, $fn=50);
    }}
    for (u = [1:SX-1]){
        for (o = [1:SY-1]){
        translate([(8*(u-1))+8,(8*(o-1))+8,0]){
           difference(){
                cylinder(h= FH, r=3.155, $fn=50);
                cylinder(h= FH, r=2.405, $fn=50);
            }
        }
    }}
    
}
else{}

















